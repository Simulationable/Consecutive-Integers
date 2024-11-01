# ConsecutiveIntegers

โปรแกรมนี้ถูกพัฒนาขึ้นมาเพื่อค้นหาตัวเลขที่ต่อเนื่องกันตามจำนวนที่กำหนด โดยแต่ละตัวเลขมีจำนวน **Distinct Prime Factors** ตามที่ระบุ เช่น ตัวเลขสองตัวแรกที่มีปัจจัยเฉพาะจำนวน 2 ปัจจัยที่แตกต่างกัน เป็นต้น

## Getting Started

### ความต้องการเบื้องต้น

- **.NET 8 SDK**
- **C# 12**

ติดตั้งโปรเจกต์นี้ผ่าน NuGet โดยใช้คำสั่งต่อไปนี้:

```bash
dotnet add package ConsecutiveIntegers
```

### การติดตั้งและเรียกใช้งาน

#### การรันโปรแกรม

คุณสามารถรันโปรแกรมได้โดยใช้คำสั่ง:

```bash
dotnet run --project ConsecutiveIntegers
```

### รูปแบบของผลลัพธ์

- ฟังก์ชันหลัก `Run` จะคำนวณหาตัวเลขชุดแรกที่แต่ละตัวมีจำนวนปัจจัยเฉพาะที่กำหนดไว้ เช่น 2, 3 หรือ 4 ปัจจัย
- สามารถใช้ฟังก์ชันแบบ asynchronous ได้เพื่อให้รองรับการคำนวณที่ใช้เวลานาน

### การทดสอบด้วย xUnit

โปรเจกต์นี้รองรับการทดสอบอัตโนมัติผ่าน **xUnit** เพื่อให้มั่นใจว่าโปรแกรมทำงานถูกต้องกับชุดข้อมูลที่แตกต่างกัน คุณสามารถรันทดสอบได้โดยใช้คำสั่ง:

```bash
dotnet test
```

โค้ดตัวอย่างสำหรับการทดสอบ:

```csharp
using Xunit;
using ConsecutivePrimeFactorsApp;

public class ConsecutivePrimeFactorsTests
{
        [Theory]
        [InlineData(2, new[] { 14, 15 })]
        [InlineData(3, new[] { 644, 645, 646 })]
        [InlineData(4, new[] { 134043, 134044, 134045, 134046 })]
        public void Test_FindConsecutiveIntegers(int consecutiveCount, int[] expectedResult)
        {
            var result = Program.FindConsecutiveIntegers(consecutiveCount);
            Assert.Equal(expectedResult, result);
        }
}
```

### การทดสอบด้วย GitHub Actions

เพิ่ม GitHub Actions สำหรับการทดสอบอัตโนมัติโดยสร้างไฟล์ `.github/workflows/dotnet.yml` ดังนี้:

```yaml
name: .NET

on:
  push:
    branches: [main]
  pull_request:
    branches: [main]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: "8.0.x"
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
      - name: Run tests
        run: dotnet test --no-build --verbosity normal
```
