import * as data from '../scripts/data.js';
import getToken from '../scripts/userToken.js';

export async function create() {
    const token = getToken();
    if (!token) {

        alert('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const context = Object.assign(this.app.userData);

    this.partial('./partials/articles/create.hbs', context);
}

export async function createPost() {
    const token = getToken();

    if (!token) {

        alert('You are not authorized!');
        return;
    }

    const categories = ['JS', 'C#', 'Java', 'Python'];
    const title = document.getElementById('title').value;
    const category = document.getElementById('category').value;
    const content= document.getElementById('content').value;

    if (title.length == 0) {

        alert('Title is required!');
        return;
    }

    if (!categories.find(c => c == category)) {

        alert('Allowed categories are: JS, C#, Java, Python');
        return;
    }

    if (content.length == 0) {

        alert('Content is required!');
        return;
    }

    try {
        const email = localStorage.getItem('email');
        const newArticle = {
            title: title,
            category: category,
            content: content,
            creator: email
        }

        const result = await data.create(newArticle);

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