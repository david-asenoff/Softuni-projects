
function matrixDiagonalSums(matrix) {

    let diagonal1 = 0, diagonal2 = 0;

    for (let row = 0; row < matrix.length; row++) {
        diagonal1 += matrix[row][row];
        diagonal2 += matrix[row][matrix.length - row - 1];
    }
    console.log(diagonal1 + ' ' + diagonal2);
}

matrixDiagonalSums([[20, 40], [10, 60]]);  // should output 80 50
matrixDiagonalSums([ [1, 2, 3], [4, 5, 6], [7, 8, 9] ]); // should output 15 15
matrixDiagonalSums([[20, 40],[10, 60]]); // should output 80 50
matrixDiagonalSums([[3, 5, 17],[-1, 7, 14],[1, -8, 89]]); // should output 99 25