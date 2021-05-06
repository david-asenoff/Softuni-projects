export function groupArticles(sortedArticles,allArticles){
    for (let i = 0; i < allArticles.length; i++) {
        let article = allArticles[i];
        if(article.category=='Python'){
            sortedArticles.PYTONarticles.push(article);
        }else if(article.category=='Java'){
            sortedArticles.JAVAarticles.push(article);
        }else if(article.category=='C#'){
            sortedArticles.CSHARParticles.push(article);
        }else if(article.category=='JS'){
            sortedArticles.JSarticles.push(article);
        }
    }
};

export function sortArticles(sortedArticles){
    Object.values(sortedArticles)
        .forEach(obj => obj.sort((a, b) => (b.title).localeCompare(a.title)));
};