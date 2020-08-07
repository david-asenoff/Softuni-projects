import { loading } from '../scripts/notification.js';
import getToken from '../scripts/userToken.js';

const appKey = `220EA63A-7B8C-0564-FF7A-DB3AA48BFA00`;
const restApiKey = `DC5B295B-F722-495D-BB65-84A818860DC4`;

function host(endpoint) {

    return `https://api.backendless.com/${appKey}/${restApiKey}/${endpoint}`;
}

const endpoints = {
    userRegisterUrl: `users/register`,
    userLoginUrl: `users/login`,
    userLogoutUrl: `users/logout`,
    recipes: `data/recipes`
}

export async function register(username, password, firstName, lastName) {

    const result = await (await fetch(host(endpoints.userRegisterUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({

            username: username,
            password: password,
            firstName: firstName,
            lastName: lastName
        })
    }))
        .json();

    return result;
}

export async function login(username, password) {

    const result = await (await fetch(host(endpoints.userLoginUrl), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({

            login: username,
            password: password
        })
    }))
        .json();

    return result;
}

export async function logout(ownerId) {


    const result = await (await fetch(endpoints.userLogoutUrl, {
        headers: {
            'user-token': token
        }
    }));

    return result;
}

export async function getRecipes(ownerId) {

    let result;

    if (!ownerId) {

        result = await (await fetch(host(endpoints.recipes))).json();

    } else {

        result = await (await (await fetch(host(endpoints.recipes + `?where=${escape(`ownerId LIKE '%${ownerId}%'`)}`)))).json();
    }

    return result;
}

export async function create(newRecipe) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newRecipe)
    }))
        .json();

    return result;
}

export async function details(recipeId) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes + `/${recipeId}`), {
        headers: {
            'user-token': token
        }
    })).json();

    return result;
}

export async function edit(recipeId, newRecipe) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes + `/${recipeId}`), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(newRecipe)
    }))
        .json();

    return result;
}

export async function apiDelete(recipeId) {

    const token = getToken();

    loading();

    const result = await (await fetch(host(endpoints.recipes + `/${recipeId}`), {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    }))
        .json();

    return result;
}

