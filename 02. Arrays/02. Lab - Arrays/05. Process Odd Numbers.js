function solve(array){
    console.log(array.filter((x,i)=>i%2!==0).map(x=>x*2).reverse().join(' '));
}

function solve2(arguments) {
    let numbers = [];

    for (let i = 0; i < arguments.length; i++) {
        if (i % 2 != 0) {
            numbers.unshift(Number(arguments[i] * 2));
        }
    }
    console.log(numbers);
}

solve2([10, 15, 20, 25]);
solve2([3, 0, 10, 4, 7, 3]);