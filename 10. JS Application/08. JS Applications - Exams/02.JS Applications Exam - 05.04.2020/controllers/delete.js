import * as data from '../scripts/data.js';
import getToken from '../scripts/userToken.js';

export async function apiDelete() {
    const token = getToken();
    if (!token) {

        alert('You are not authorized!');
        return;
    }

    try {

        const articleId = this.params.id;
        const result = await data.deleteArticle(articleId);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect('#/home');

    } catch (err) {

        console.log(err);
        alert(err);
    }
}
