function solve(str1, str2, str3) {

let sumLength;

let averageLength;

let firstArgLength = str1.length;

let secondArgLength = str2.length;

let thirdArgLength = str3.length;

sumLength = firstArgLength + secondArgLength + thirdArgLength;

averageLength = Math.floor(sumLength / 3);

console.log(sumLength);

console.log(averageLength);

}
