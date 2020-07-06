function getInfo() {

    let busNumberInput = document.getElementById('stopId');
   
    let divName = document.getElementById('stopName');
    let ul = document.getElementById('buses');

    document.getElementById('buses').innerHTML = '';
    let url = `https://judgetests.firebaseio.com/businfo/${busNumberInput.value}.json`;

    const xhr = new XMLHttpRequest();

    xhr.open('GET', url);

    xhr.onreadystatechange = function () {
        if (this.status === 200 && this.readyState === 4) {

            let busInfo = JSON.parse(this.responseText);

            divName.innerHTML = busInfo.name;

            for (let key in busInfo.buses) {
                let newLi = document.createElement('li');
                newLi.textContent = `Bus ${key} arrives in ${busInfo.buses[key]} minutes`;
                ul.appendChild(newLi);
            }
        } else {
            divName.innerHTML = 'Error';
        }
    }

    xhr.send();

    busNumberInput.value = '';

}