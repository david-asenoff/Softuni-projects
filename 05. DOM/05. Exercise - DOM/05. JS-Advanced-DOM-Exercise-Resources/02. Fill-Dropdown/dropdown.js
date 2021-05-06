function addItem() {
    let menu =  document.getElementById("menu");
    let newItemText = document.getElementById("newItemText").value;
    let newItemValue = document.getElementById("newItemValue").value;
    var opt = document.createElement('option');
    opt.appendChild( document.createTextNode(newItemText) );
    opt.value = newItemValue; 
    menu.appendChild(opt);
    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
}