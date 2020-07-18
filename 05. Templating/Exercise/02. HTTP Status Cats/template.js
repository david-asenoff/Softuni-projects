(async () => {
    await renderCatTemplate();
    await attachEvents();

    const renderCatTemplate = async () => {
        const catsUl = document.querySelector("#allCats > ul");

        const cats = window.cats;
        const template = await fetch("template.hbs")
            .then(data => data.text());

        const catsTemplate = Handlebars.compile(template);
        const context = { cats }

        catsUl.innerHTML += catsTemplate(context);
    };

    const attachEvents = async () => {
        const buttons = document.querySelectorAll(".info > button");
        buttons.forEach((btn) => {
            btn.addEventListener("click", onBtnClick);
        })
    };

    const onBtnClick = async e => {
        const button = e.target;
        const statusDiv = e.target.nextElementSibling;

        const buttonTextSwitch = {
            "Show status code": "Hide status code",
            "Hide status code": "Show status code",
        }

        const displayStyleSwitch = {
            "none": "block",
            "block": "none",
        }

        button.textContent = buttonTextSwitch[button.textContent];
        statusDiv.style.display = displayStyleSwitch[statusDiv.style.display];
    };
})();
