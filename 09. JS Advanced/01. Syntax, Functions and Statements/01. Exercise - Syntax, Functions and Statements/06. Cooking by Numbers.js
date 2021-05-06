function solve(arguments) {
    let number = Number(arguments[0]);

    for (let i = 1; i < arguments.length; i++) {
        switch (arguments[i]) {
            case 'chop': number /= 2; console.log(number);
                break;
            case 'dice': number = Math.sqrt(number); console.log(number);
                break;
            case 'spice': number += 1; console.log(number);
                break;
            case 'bake': number *= 3; console.log(number);
                break;
            case 'fillet': number *= 0.80; console.log(number);
                break;
        }
    }
}

// solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);	
// 16,8,4,2,1


// solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);	
// 3,4,2,6,4.8
