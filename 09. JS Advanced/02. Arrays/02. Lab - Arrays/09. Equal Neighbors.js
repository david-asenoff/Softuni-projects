function solve(input) {
    let count = 0;
    for (let row = 0; row < input.length; row++) {
        if (row !== input.length - 1) {
            for (let j = 0; j < input[row].length; j++) {
                if (input[row][j] === input[row + 1][j]) {
                    count++;
                }
                if (input[row][j] === input[row][j + 1]) {
                    count++;
                }
            }   
        } else {
            for (let j = 0; j < input[row].length; j++) {
                if (input[row][j] === input[row][j + 1]) {
                    count++;
                }
            }
        }
    }
    console.log(count);
}