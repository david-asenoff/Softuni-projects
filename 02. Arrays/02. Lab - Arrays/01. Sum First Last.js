function solve(arguments){
    const firstNum = parseInt(arguments[0]);
    const lastNum = parseInt(parseInt(arguments[arguments.length-1]));
    return console.log(firstNum+lastNum);
}

// solve(['20', '30', '40']);