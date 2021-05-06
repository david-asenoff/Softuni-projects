function solve(arguments) {
    let numbers = [];

    for (let i = 0; i < arguments.length; i++) {
        if (arguments[i] < 0) {
            numbers.unshift(arguments[i]);
        } else {
            numbers.push(arguments[i]);
        }
    }
    console.log(numbers);
}

solve([3, -2, 0, -1,0,0,5,100,1000,0,0,0]);