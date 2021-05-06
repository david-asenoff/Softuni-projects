function solve(arguments) {
    console.log(arguments.filter((x,i)=>i%2===0).join(' '));
}

solve(['20', '30', '40']);