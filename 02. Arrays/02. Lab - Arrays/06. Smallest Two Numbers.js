function solve(arguments) {
    console.log(arguments.sort((a, b) => a - b).slice(0, 2).join(" "));
}

solve([30, 15, 50, 5]);