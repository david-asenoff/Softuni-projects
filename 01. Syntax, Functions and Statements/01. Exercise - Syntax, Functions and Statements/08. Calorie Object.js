function solve(params) {
    const calorie = {};

    for (let i = 0; i < params.length; i += 2) {
        let name = params[i];
        let value = Number(params[i + 1]);

        calorie[name] = value;
    }

    console.log(calorie);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);
