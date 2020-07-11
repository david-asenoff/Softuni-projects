const restApiKey = "23056459-8F0D-4A24-BE5D-4E766AC35CD5";
const appId = "42F3BF79-A842-320D-FFD8-3853C995B800";
const baseUrl = `https://api.backendless.com/${appId}/${restApiKey}/data/ELibrary`;

export async function getAllBooks(){
    const response = await (fetch(baseUrl));
    const data = await response.json();
    return data;
};

export async function createBook(bookObj){
    return await fetch(baseUrl,{
        method: 'POST',
        body: JSON.stringify(bookObj)
    })
};

export async function updateBook(bookObj, bookId){
    return fetch(`${baseUrl}/${bookId}`,{
    method: 'PUT',
    body: JSON.stringify(bookObj)
    });
};

export async function deleteBook(bookId){
    return fetch(`${baseUrl}/${bookId}`,{
    method: 'DELETE'
    });
};