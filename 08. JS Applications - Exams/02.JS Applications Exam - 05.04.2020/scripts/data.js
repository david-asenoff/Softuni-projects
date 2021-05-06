import getToken from '../scripts/userToken.js';

const appKey = `49FF4C16-678C-10A4-FF1E-92AF099A4E00`;
const restApiKey = `9BC5F54D-7B9A-4C91-A3DE-6CE00FAB2610`;

function host(endpoint) {

    return `https://api.backendless.com/${appKey}/${restApiKey}/${endpoint}`;
}

const endpoints = {
    userRegisterUrl: `users/register`,
    userLoginUrl: `users/login`,
    userLogoutUrl: `users/logout`,
    articles: `data/articles`
}

export async function register(email, password) {

    const result = await (await fetch(host(endpoints.userRegisterUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
                email,
                password
        })
    }))
        .json();

    return result;
}

export async function login(email, password) {

    const result = await (await fetch(host(endpoints.userLoginUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({

            login: email,
            password: password
        })
    }))
        .json();

    return result;
}

export async function logout() {
    const result = await (await fetch(host(endpoints.userLogoutUrl), {
        headers: {
            'user-token': getToken()
        }
    }));

    return result;
}

export async function getArticles() {

    let result = await (await fetch(host(endpoints.articles))).json();

    return result;
}

export async function create(newArticle) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.articles), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newArticle)
    }))
        .json();

    return result;
}

export async function details(articleId) {

    const token = getToken();
    const result = await (await fetch(host(endpoints.articles + `/${articleId}`), {
        headers: {
            'user-token': token
        }
    })).json();

    return result;
}

export async function edit(objectId, newArticle) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.articles + `/${objectId}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newArticle)
    }))
        .json();

    return result;
}

export async function deleteArticle(objectId) {

    const token = getToken();

    const result = await (await fetch(host(endpoints.articles + `/${objectId}`), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    }))
        .json();

    return result;
}

