const kyivstarIndexes = "0((67|68|77|96|97|98))";
const vodafoneIndexes = "0((50|66|95|99|75))";
const lifecellIndexes = "0((63|73|93))";

const kyivstarPatterns = [
  new RegExp(`^\\+38 ${kyivstarIndexes} \\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^\\+38\\(${kyivstarIndexes}\\)\\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^\\+38\\(${kyivstarIndexes}\\)\\d{7}$`),
  new RegExp(`^${kyivstarIndexes} \\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^${kyivstarIndexes}\\d{7}$`)
];

const vodafonePatterns = [
  new RegExp(`^\\+38 \\(${vodafoneIndexes}\\) \\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^\\+38\\(${vodafoneIndexes}\\)\\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^\\+38\\(${vodafoneIndexes}\\)\\d{7}$`),
  new RegExp(`^${vodafoneIndexes} \\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^${vodafoneIndexes}\\d{7}$`)
];

const lifecellPatterns = [
  new RegExp(`^\\+38 \\(${lifecellIndexes}\\) \\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^\\+38\\(${lifecellIndexes}\\)\\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^\\+38\\(${lifecellIndexes}\\)\\d{7}$`),
  new RegExp(`^${lifecellIndexes} \\d{3}-\\d{2}-\\d{2}$`),
  new RegExp(`^${lifecellIndexes}\\d{7}$`)
];

const numbers = [
  "+38 (050) 123-45-67",
  "+38(067)123-45-67",
  "+38(067)1234567",
  "050 123-45-67",
  "0501234567",
  "050-123-45-67",
  "050 123 45 67",
  "+38(073)1234567",
  "(063) 123-45-67",
  "(96) 123-45-67",
  "93 123 45 67",
  "093 123-45-67",
  "73-123-45-67",
  "97 1234567",
  "98 12 34567",
  "98 123 45 67",
  "0671234567",
  "050123456789"
];

function showCompliance(number, showRightPattern = true) {
  for (let el of kyivstarPatterns) {
    if (el.test(number)) {
      console.log(`${number} ${"\x1b[32m"}passed${showRightPattern ? ` ${"\x1b[0m"}"${"\x1b[33m"}${el}${"\x1b[0m"}"` : " successfully!"} (Kyivstar)`);
      return;
    }
  }

  for (let el of vodafonePatterns) {
    if (el.test(number)) {
      console.log(`${number} ${"\x1b[32m"}passed${showRightPattern ? ` ${"\x1b[0m"}"${"\x1b[33m"}${el}${"\x1b[0m"}"` : " successfully!"} (Vodafone)`);
      return;
    }
  }

  for (let el of lifecellPatterns) {
    if (el.test(number)) {
      console.log(`${number} ${"\x1b[32m"}passed${showRightPattern ? ` ${"\x1b[0m"}"${"\x1b[33m"}${el}${"\x1b[0m"}"` : " successfully!"} (Lifecell)`);
      return;
    }
  }

  console.log(number + " doesn`t match any pattern!");
}

for (const num of numbers) {
  showCompliance(num, true);
}
