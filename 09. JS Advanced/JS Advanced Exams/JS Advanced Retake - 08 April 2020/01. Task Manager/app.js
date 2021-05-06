function solve() {
   
    var addTaskHeaderInput = document.querySelector('#task');
    var addTaskDescriptionInput = document.querySelector('#description');
    var addTaskDueDateInput = document.querySelector('#date');
    var openSection = document.querySelector('body > main > div > section:nth-child(2) > div:nth-child(2)');
    var inProgressSection = document.querySelector('#in-progress');
    var completeSection = document.querySelector('body > main > div > section:nth-child(4) > div:nth-child(2)');
var buttonAdd = document.querySelector('#add');
    

    buttonAdd.addEventListener('click', function (e) {
        e.preventDefault();
        var task = addTaskHeaderInput.value;
        var description = addTaskDescriptionInput.value;
        var date = addTaskDueDateInput.value;
        if(task!=='' && description !=='' && date!==''){
            
            var article = document.createElement('article');
            var h3 = document.createElement('h3');
            h3.textContent=task;
            var paragraph1 = document.createElement('p');
            paragraph1.textContent=`Description: ${description}`;
            var paragraph2 = document.createElement('p');
            paragraph2.textContent = `Due Date: ${date}`;

            var div = document.createElement('div');
            div.classList.add('flex');

            var greenStart = document.createElement('button');
            greenStart.classList.add('green');
            greenStart.textContent='Start';

            var redDelete = document.createElement('button');
            redDelete.classList.add('red');
            redDelete.textContent='Delete';

            div.appendChild(greenStart);
            div.appendChild(redDelete);

            article.appendChild(h3);
            article.appendChild(paragraph1);
            article.appendChild(paragraph2);
            article.appendChild(div);

            openSection.appendChild(article);
            addTaskHeaderInput.value='';
            addTaskDescriptionInput.value='';
            addTaskDueDateInput.value='';

            greenStart.addEventListener('click',function (e){
                e.preventDefault();
                div.removeChild(greenStart);
                var orangeFinish = document.createElement('button');
                orangeFinish.classList.add('orange');
                orangeFinish.textContent='Finish';
                div.appendChild(orangeFinish);
                inProgressSection.appendChild(article);
                // openSection.removeChild(article);

                orangeFinish.addEventListener('click',function(e){
                    e.preventDefault();
                    div.remove();
                    inProgressSection.removeChild(article);
                    completeSection.appendChild(article);
                });
            });

            redDelete.addEventListener('click',function (e){
                e.preventDefault();
                article.remove();
            });
        }

    });
}