function solve(input){

    var weekday = new Array(7);
weekday['Monday'] = 1;
weekday['Tuesday'] = 2;
weekday['Wednesday'] = 3;
weekday['Thursday'] = 4;
weekday['Friday'] = 5;
weekday['Saturday'] = 6;
weekday['Sunday'] = 7;
    
console.log(input=='Monday'||
    input=='Tuesday'||
    input=='Wednesday'||
    input=='Thursday'||
    input=='Friday'||
    input=='Saturday'||
    input=='Sunday'
?weekday[input]:'error');
}
//solve(1)