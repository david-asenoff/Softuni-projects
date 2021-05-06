(async () => {
    await render();
    await attachEvents();

    async function render() {
        const monkeysDiv = document.querySelector("div.monkeys");

        const template = await fetch("template.hbs")
            .then(data => {
                return data.text();
            });

        const monkeysTemplate = Handlebars.compile(template);

        const monkeys = window.monkeys;
        const context = { monkeys };

        monkeysDiv.innerHTML += monkeysTemplate(context);
    }

    const attachEvents = async () => {
        const buttons = document.querySelectorAll(".monkey > button");

        buttons.forEach((button) => {
            button.addEventListener("click", onBtnClick);
        })
    };

    const onBtnClick = async e => {
        const button = e.target;
        const infoParagraph = button.nextElementSibling;

        const buttonTextSwitch = {
            "Info": "Hide",
            "Hide": "Info",
        }

        const displayStyleSwitch = {
            "none": "block",
            "block": "none",
        }

        button.textContent = buttonTextSwitch[button.textContent];
        infoParagraph.style.display = displayStyleSwitch[infoParagraph.style.display];
    };
})()