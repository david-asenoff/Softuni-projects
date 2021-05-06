function solve(input) {
    let step = Number(input.pop());
    return input
        .filter((el, index) => {
            return index % step === 0;
        })
        .join("\n");
}