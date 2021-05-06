let expect = require('chai').expect;
let should = require('chai').should;
let assert = require('chai').assert;
let sum = require('./isOddOrEven');
let lookupChar = require('./charLookUp');
let mathEnforcer = require('./mathEnforcer');

describe(`isOddOrEven.js behaviour`,function(){
    describe(`Check string length with invalid types`,function(){ 
        it(`numeric type should return undefined`,function(){  
            let actualResult= sum(5);  
            let expectedResult = undefined;   
            let errorMessage=`The result should be`;
            assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
        })
        it(`Null type should return undefined`,function(){  
            let actualResult= sum(null);  
            let expectedResult = undefined;   
            let errorMessage=`The result should be`;
            assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
        })
        it(`Array type should return undefined`,function(){  
            let actualResult= sum([]);  
            let expectedResult = undefined;   
            let errorMessage=`The result should be`;
            assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
        })
        it(`Object type should return undefined`,function(){  
            let actualResult= sum({name:'David Asenov'});  
            let expectedResult = undefined;   
            let errorMessage=`The result should be`;
            assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
        })
    })
    describe(`Check the string length with valid type`,function(){ 
        describe(`odd cases`,function(){ 
            it(`should return odd`,function(){  
                let actualResult= sum('test1');  
                let expectedResult = 'odd';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
            it(`Empty string should return odd`,function(){  
                let actualResult= sum(' ');  
                let expectedResult = 'odd';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
            it(`Empty string should return odd`,function(){  
                let actualResult= sum('Unit testing and modules.');  
                let expectedResult = 'odd';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
            it(`Empty string should return odd`,function(){  
                let actualResult= sum('JS-Applications');  
                let expectedResult = 'odd';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
        })
        describe(`even cases`,function(){ 
            it(`should return even`,function(){  
                let actualResult= sum('test');  
                let expectedResult = 'even';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
            
            it(`should return even`,function(){  
                let actualResult= sum('GitHub');  
                let expectedResult = 'even';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
            it(`Empty string should return even`,function(){  
                let actualResult= sum('');  
                let expectedResult = 'even';   
                let errorMessage=`The result should be`;
                assert.equal(actualResult,expectedResult,`${errorMessage} ${expectedResult}`);
            })
        })
    })
})

describe("charLookUp.js behaviour", function () {
    it('with a non-string first parameter should return undefined', function () {
        expect(lookupChar(13, 0)).to.equal(undefined, "The function did not return correct result");
    });
    it('with a non-string second parameter should return undefined', function () {
        expect(lookupChar("pesho", "gosho")).to.equal(undefined, "The function did not return correct result");
    });
    it('with a floating point number second parameter should return undefined', function () {
        expect(lookupChar("pesho", 3.12)).to.equal(undefined, "The function did not return correct result");
    });
    it('with an incorrect index value should return incorrect index', function () {
        expect(lookupChar("gosho", 13)).to.equal("Incorrect index", "The function did not return correct result");
    });
    it('with a negative index value should return incorrect index', function () {
        expect(lookupChar("stamat", -1)).to.equal("Incorrect index", "The function did not return correct result");
    });
    it('with an index value equal to string length, should return incorrect index', function () {
        expect(lookupChar("pesho", 5)).to.equal("Incorrect index", "The function did not return correct result");
    });
    it('with correct parameters, should return correct value', function () {
        expect(lookupChar("pesho", 0)).to.equal("p", "The function did not return correct result");
    });
    it('with correct parameters should return correct value', function () {
        expect(lookupChar("stamat", 3)).to.equal("m", "The function did not return correct result");
    });
});

describe("mathEnforcer.js behaviour", function () {
    describe('addFive', function () {
       it("should return undefined for non-number parameter",function () {
           expect(mathEnforcer.addFive("5")).to.be.equal(undefined);
       });
        it("should return correct result for positive integer parameter", function () {
            expect(mathEnforcer.addFive(10)).to.be.equal(15);
        });
        it("should return correct result for negative integer parameter", function () {
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });
        it("should return correct result for floating point parameter", function () {
            expect(mathEnforcer.addFive(3.14)).to.be.closeTo(8.14, 0.01);
        });
    });
 
     describe('subtractTen', function () {
         it("should return undefined for non-number parameter",function () {
             expect(mathEnforcer.subtractTen("5")).to.be.equal(undefined);
         });
         it("should return correct result for positive integer parameter", function () {
             expect(mathEnforcer.subtractTen(10)).to.be.equal(0);
         });
         it("should return correct result for negative integer parameter", function () {
             expect(mathEnforcer.subtractTen(-5)).to.be.equal(-15);
         });
         it("should return correct result for floating point parameter", function () {
             expect(mathEnforcer.subtractTen(3.14)).to.be.closeTo(-6.86, 0.01);
         });
     });
 
     describe('sum', function () {
         it("should return undefined for non-number first parameter", function () {
             expect(mathEnforcer.sum("5", 5)).to.be.equal(undefined);
         });
         it("should return undefined for non-number second parameter", function () {
             expect(mathEnforcer.sum(5, "5")).to.be.equal(undefined);
         });
         it("should return correct result for integer parameters", function () {
             expect(mathEnforcer.sum(5, -3)).to.be.equal(2);
         });
         it("should return correct result for floating point parameters", function () {
             expect(mathEnforcer.sum(2.7, 3.4)).to.be.closeTo(6.1, 0.01);
         })
     })
 });
