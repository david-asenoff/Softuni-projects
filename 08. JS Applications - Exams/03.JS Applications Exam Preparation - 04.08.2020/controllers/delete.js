import { loadError, loadInfo} from '../scripts/notification.js';
import * as data from '../scripts/data.js';
import getToken from '../scripts/userToken.js';

export default async function apiDelete() {

    const token = getToken();

    if (!token) {

        loadError('You are not authorized!');
        return;
    }

    try {

        const recipeId = this.params.id;

        const result = await data.apiDelete(recipeId);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        loadInfo('Your recipe was archived');

        this.redirect(`#/home`);

    } catch (error) {

        console.log(error);
        loadError(error);
    }
}