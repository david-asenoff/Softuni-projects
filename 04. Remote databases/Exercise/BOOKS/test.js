import * as data from './backendless-requests.js'; // Have to add .js

const loadBtn = document.querySelector(`#loadBooks`);
const booksTable = document.querySelector(`body > table > tbody`);

loadBtn.addEventListener('click',async (e)=>{
let books = await data.getAllBooks();
booksTable.innerHTML='';

books.forEach(x => {
    
    let deleteButton = document.createElement('button');
    deleteButton.addEventListener('click',deleteBook);
    deleteButton.textContent='Delete';

    let editButton = document.createElement('button');
    editButton.addEventListener('click',deleteBook);
    editButton.textContent='Edit';

    let tr = document.createElement('tr');
    tr.innerHTML = `<td>${x.title}</td>
    <td>${x.author}</td>
    <td>${x.isbn}</td>
    <td>
        ${editButton.outerHTML}
        ${deleteButton.outerHTML}
    </td>`;
    booksTable.appendChild(tr);
})
async function deleteBook(e){
    const dataId = e.target.parentElement.parentElement
    .getAttribute("data-id");

    await data.deleteBook(dataId);
}
})

