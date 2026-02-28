using System;

namespace Baloot.Core.Rng
{
    public class DeterministicRng
    {
        private ulong _state;

        public DeterministicRng(ulong seed)
        {
            // خوارزمية XorShift تتطلب ألا يكون الـ State صفراً.
            // إذا كان الـ Seed صفراً، نضع قيمة ابتدائية صلبة (Fallback).
            _state = seed == 0 ? 0x853c49e6748fea9bUL : seed;
        }

        // 1. توليد رقم 64-bit عشوائي باستخدام خوارزمية XorShift64 (سريعة وحتمية)
        private ulong NextUlong()
        {
            ulong x = _state;
            x ^= x << 13;
            x ^= x >> 7;
            x ^= x << 17;
            _state = x;
            return x;
        }

        // 2. دالة تعيد رقماً في النطاق [0, n) بدون انحياز (Unbiased)
        public int NextInRange(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException(nameof(n), "n must be strictly positive.");

            ulong un = (ulong)n;

            // Rejection Sampling: للتخلص من الـ Modulo Bias
            // نحسب الحد الأقصى الذي يقبل القسمة على n بدون باقٍ
            ulong limit = ulong.MaxValue - (ulong.MaxValue % un);

            ulong sample;
            do
            {
                sample = NextUlong();
            }
            while (sample >= limit); // نرفض الأرقام التي تقع في منطقة الانحياز

            return (int)(sample % un);
        }

        // 3. خوارزمية Fisher-Yates Shuffle لمصفوفة int[]
        public void Shuffle(int[] array)
        {
            if (array == null || array.Length < 2)
                return;

            for (int i = array.Length - 1; i > 0; i--)
            {
                // جلب رقم عشوائي j بحيث 0 <= j <= i
                int j = NextInRange(i + 1);

                // Swap
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}