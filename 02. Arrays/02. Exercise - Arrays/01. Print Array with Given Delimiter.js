function solve(array){
    console.log(array.join(array.pop()));
}

solve(['One', 'Two', 'Three', 'Four', 'Five', '-']); //One-Two-Three-Four-Five
solve(['How about no?', 'I','will', 'not', 'do', 'it!', '_']); //How about no?_I_will_not_do_it!