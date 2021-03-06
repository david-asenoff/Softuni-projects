function solve(input){
    let result='<table>';

    for (const item of input) {
        let line = item.split(',');
        let obj = JSON.parse(line);
        result += "\n\t<tr>" + "\n\t\t<td>" + obj['name'] + "</td>"
                             + "\n\t\t<td>" + obj['position'] + "</td>" 
                             + "\n\t\t<td>" + obj['salary'] + "</td>\n\t</tr>";
    }
    result+='\n</table>'
    return console.log(result);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
);