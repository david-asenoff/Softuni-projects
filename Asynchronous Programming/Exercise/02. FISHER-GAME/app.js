function attachEvents() {
    const mainUrl = `https://fisher-game.firebaseio.com/catches.json`;
    const loadButton = document.querySelector(`body > aside > button`);
    const addButton = document.querySelector(`#addForm > button`);
    let anglerInput= document.querySelector(`#addForm > input.angler`);
    let weightInput= document.querySelector(`#addForm > input.weight`);
    let speciesInput= document.querySelector(`#addForm > input.species`);
    let locationInput= document.querySelector(`#addForm > input.location`);
    let baitInput= document.querySelector(`#addForm > input.bait`);
    let captureTimeInput= document.querySelector(`#addForm > input.captureTime`);
    let catchesDiv= document.querySelector(`#catches`);

    loadButton.addEventListener('click',listAllCatches);
    addButton.addEventListener('click',createCatch);

    async function listAllCatches(){
        catchesDiv.innerHTML='Loading...';
        loadButton.disable=true;
        let result = await fetch(mainUrl)
        .then(x=>x.json())
        .then((objects)=>{
            catchesDiv.innerHTML='';
            for (const key in objects) {
                createCatchDiv(objects[key],key)
              }
        });
    }
    async function createCatch(e){
        
        const objToPost = {angler:anglerInput.value, 
                           weight:weightInput.value,
                           species:speciesInput.value,
                           location:locationInput.value,
                           bait:baitInput.value, 
                           captureTime:captureTimeInput.value};

        await fetch(mainUrl, {
            method: "POST",
            body: JSON.stringify(objToPost)
        })
            .then(() => listAllCatches()) //reload
            .catch((e) => new Error(e));
    }
    async function updateCatch(e){
        const catchId = e.target.parentElement.getAttribute("data-id");
        let currentCatchDiv = document.querySelector(`[data-id=${catchId}]`);
        const url = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;

        // Класа на всеки елемент съвпада с името на пропъртито във обекта - напиши един селектор,
        //  който хваща всички input полета в съответния div, 
        //  обхожда ги и поставя тяхната стойност в обекта с име, посочено в атрибута клас.
        //  В по-нататъшните лекции ще видим по удачен начин, използвайки form и атрибут name на всяко поле :)
        const objToPost = {
            angler:currentCatchDiv.getElementsByClassName("angler")[0].value,
            weight:currentCatchDiv.getElementsByClassName("weight")[0].value,
            species:currentCatchDiv.getElementsByClassName("species")[0].value,
            location:currentCatchDiv.getElementsByClassName("location")[0].value,
            bait:currentCatchDiv.getElementsByClassName("bait")[0].value, 
            captureTime:currentCatchDiv.getElementsByClassName("captureTime")[0].value};
        
        await fetch(url,{
            method:"PUT",
            body: JSON.stringify(objToPost)
        })
        .then(()=>listAllCatches())
        .catch((e) => new Error(e));
    }
    async function deleteCatch(e){
        const catchId = e.target.parentElement.getAttribute("data-id");
        const url = `https://fisher-game.firebaseio.com/catches/${catchId}.json`
        await fetch(url,{
            method:"DELETE",
        })
        .then(()=>listAllCatches())
        .catch((e) => new Error(e));
    }
    async function createCatchDiv(obj,key){
        let catchDiv = document.createElement('div');
        catchDiv.className='catch';
        catchDiv.setAttribute('data-id',key);

        catchDiv.innerHTML=`<label>Angler</label>
        <input type="text" class="angler" value="${obj.angler}"/>
        <hr>
        <label>Weight</label>
        <input type="number" class="weight" value="${obj.weight}"/>
        <hr>
        <label>Species</label>
        <input type="text" class="species" value="${obj.species}"/>
        <hr>
        <label>Location</label>
        <input type="text" class="location" value="${obj.location}"/>
        <hr>
        <label>Bait</label>
        <input type="text" class="bait" value="${obj.bait}"/>
        <hr>
        <label>Capture Time</label>
        <input type="number" class="captureTime" value="${obj.captureTime}"/>
        <hr>`;

        const updateBtn = document.createElement("button");
        updateBtn.textContent = "Update";
        updateBtn.addEventListener("click", updateCatch)

        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete"
        deleteBtn.addEventListener("click", deleteCatch);

        catchDiv.append(updateBtn, deleteBtn);

        catchesDiv.appendChild(catchDiv);
    }
}

attachEvents();

