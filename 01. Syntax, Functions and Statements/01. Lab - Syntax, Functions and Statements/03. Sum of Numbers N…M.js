function solve (n,m){
    let sum=0;
    let num1= Number(n);
    let num2=Number(m);
    for (let index = num1; index <= num2; index++) {
        sum+=index;
    }
    console.log(sum);
}
//solve(1,5)