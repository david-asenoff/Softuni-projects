let assert = require('chai').assert;// взема функционалността която идва от библиотеката Chai
let expect = require('chai').expect;
let sum = require('./sumNumbers');//импортиране на даден модул/функция
let isSymmetric = require('./checkForSymmetry');
let rgbToHexColor = require('./rgb-to-hex');
let createCalculator = require('./addSubtract');

describe(`sum() behaviour`,function(){        //името на функцията чието поведение изследваме
    it(`check the return result`,function(){  // коя специфична част от модула изследваме,  името на конкретният юнит тест
        let actualResult= sum([5,10]);  //истинският/настоящият резултат от изследваната функционалност
        let expectedResult = 5+10;      //очакван/верен резултат от изследваната функционалност
        let errorMessage=`The result should be`;// конкретният error message при случай, че assert не мине успешно
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
})

describe(`isSymmetric() behaviour`,function(){        //името на функцията чието поведение изследваме
    it(`non array should return false`,function(){  // коя специфична част от модула изследваме,  името на конкретният юнит тест
        let actualResult= isSymmetric('test');  //истинският/настоящият резултат от изследваната функционалност
        let expectedResult = false;      //очакван/верен резултат от изследваната функционалност
        let errorMessage=`The result should be`;// конкретният error message при случай, че assert не мине успешно
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
    it(`non symetric array should return false`, function(){
        let actualResult = isSymmetric([1,2,3,4,5,6,7,8,9,10]);
        let expectedResult = false;
        let errorMessage=`The result should be`;
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
    it(`symetric array should return true`, function(){
        let actualResult = isSymmetric([1,2,3,4,5,5,4,3,2,1]);
        let expectedResult = true;
        let errorMessage=`The result should be`;
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
})

describe(`rgbToHexColor() behaviour`,function(){        
    it(`non positive int Red should return undefined`,function(){  
        let actualResult= rgbToHexColor('test',100,255);  
        let expectedResult = undefined;     
        let errorMessage=`The result should be`; 
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
    it(`non positive int Blue should return undefined`,function(){  
        let actualResult= rgbToHexColor(0,-100,255);  
        let expectedResult = undefined;     
        let errorMessage=`The result should be`; 
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
    it(`non positive int Green should return undefined`,function(){  
        let actualResult= rgbToHexColor(0,200,-255);  
        let expectedResult = undefined;     
        let errorMessage=`The result should be`; 
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
    it(`should return #0064FF`,function(){  
        let actualResult= rgbToHexColor(0,100,255);  
        let expectedResult = '#0064FF';     
        let errorMessage=`The result should be`; 
        assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
    })
})

describe("createCalculator()", function () {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    it("should return 0 for get;", function () {
        let value = calc.get();
        expect(value).to.be.equal(0);
    });
    it("should return 5 after add(2); add(3);", function () {
        calc.add(2);
        calc.add(3);
        let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return -5 after subtract(3); subtract(2)", function () {
        calc.subtract(3);
        calc.subtract(2);
        let value = calc.get();
        expect(value).to.be.equal(-5);
    });
    it("should return 4.2 after add(5.3); subtract(1.1);", function () {
        calc.add(5.3);
        calc.subtract(1.1);
        let value = calc.get();
        expect(value).to.be.equal(5.3 - 1.1);
    });
    it("should return 2 after add(10); subtract('7'); add('-2'); subtract(-1)", function () {
        calc.add(10);
        calc.subtract('7');
        calc.add('-2');
        calc.subtract(-1);
        let value = calc.get();
        expect(value).to.be.equal(2);
    });
    it("should return NaN for add(string)", function () {
        calc.add('hello');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
    it("should return NaN for subtarct(string)", function () {
        calc.subtract('hello');
        let value = calc.get();
        expect(value).to.be.NaN;
    });
});