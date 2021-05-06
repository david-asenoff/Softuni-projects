import * as data from '../scripts/data.js';
import {groupArticles, sortArticles} from '../scripts/sorter.js';

export default async function () {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        article: await this.load('./partials/articles/article.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    let allArticles = await data.getArticles();
    let sortedArticles = {
        JSarticles: [],
        CSHARParticles: [],
        JAVAarticles: [],
        PYTONarticles: []
    }
    groupArticles(sortedArticles,allArticles);
    sortArticles(sortedArticles);

    this.app.userData.articles = sortedArticles;
    const context = Object.assign(sortedArticles, this.app.userData);

    this.partial('./partials/home.hbs', context);
    console.log(this.app.userData);
}