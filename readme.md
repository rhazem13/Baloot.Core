# Baloot Core Engine - Deterministic RNG

هذا المستودع يحتوي على التنفيذ المبدئي لمولد الأرقام العشوائية الحتمي (Deterministic RNG) وخوارزمية خلط الأوراق (Fisher-Yates Shuffle) المطلوبة لمحرك لعبة البلوت.

## 🏗️ بنية المشروع (Project Structure)
* `Baloot.Core/` : مكتبة المحرك الأساسية (Target: `.NET Standard 2.1`). مبنية بالكامل من الصفر بدون أي اعتماديات خارجية (Zero Dependencies).
* `Baloot.Tests/` : مشروع اختبارات الوحدة باستخدام xUnit (Target: `.NET 10.0`).

## 🚀 التشغيل الفوري (Quick Start - Copy/Paste)

تأكد من تثبيت [.NET 10 SDK](https://dotnet.microsoft.com/download) أو أحدث على جهازك. 
افتح موجه الأوامر (Terminal / CMD) في المجلد الرئيسي للمشروع، وانسخ الأوامر التالية:

```bash
# 1. بناء المشروع (Build)
dotnet build

# 2. تشغيل الاختبارات وإثبات الحتمية (Run Tests)
dotnet test --logger "console;verbosity=detailed"