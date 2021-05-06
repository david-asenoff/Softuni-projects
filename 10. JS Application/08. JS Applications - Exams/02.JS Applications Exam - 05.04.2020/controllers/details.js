import * as data from '../scripts/data.js';
import getToken from '../scripts/userToken.js';

export default async function details() {

    const token = getToken();

    if (!token) {

        alert('You are not authorized!');
        return;
    }

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    const articleId = this.params.id;
    const article = await data.details(articleId);

    const email = localStorage.getItem('email');

    if (email == article.creator) {

        this.app.userData.isCreator = true;

    } else {

        this.app.userData.isCreator = false;
    }

    const context = Object.assign(article, this.app.userData);
    console.log('this is from details.js:');
    console.log(context);
    this.partial('./partials/articles/details.hbs', context);
}