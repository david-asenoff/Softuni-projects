function fruitCalculator(fruit, weight, money){
     if(typeof money === 'number'&& typeof weight === 'number'&& typeof fruit === 'string')
        console.log(`I need $${((weight/1000)*money).toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${fruit}.`);
        else
        console.log(`Not valid parameters`)
}