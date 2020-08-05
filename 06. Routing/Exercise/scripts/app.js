import home from '../controllers/home.js';
import about from '../controllers/about.js';
import * as users from '../controllers/users.js';
import * as catalog from '../controllers/catalog.js';
import * as team from '../controllers/team.js';

window.addEventListener('load', () => {
    const app = Sammy('#main', function () { // къде да се визуализира съдържанието(div с id main),
                                             // callback функция която ще се изпълни когато нещо се случи в приложението
                                             // this === Sammy.Application , функции свързани с нови раутове
        this.use('Handlebars', 'hbs');

        this.userData = { //съхранява потребителската сесия
            loggedIn: false,
            hasTeam: false,
            username: undefined,
            userId: undefined,
            teamId: undefined,
        };

        this.get('index.html', home); // this === Sammy.EventContext , фунции даващи информация за query strings и  params на контролера
        this.get('#/home', home);     // # е метод за по-удобно рутиране.
        this.get('/', home);

        this.get('#/about', about);

        this.get('#/login', users.loginGet);
        this.post('#/login', (ctx) => { users.loginPost.call(ctx); });

        this.get('#/register', users.registerGet);
        this.post('#/register', (ctx) => { users.registerPost.call(ctx); });
        
        this.get('#/logout', users.logoutGet);

        this.get('#/catalog', catalog.teamCatalog);
        this.get('#/catalog/:id', catalog.teamDetails); //:id ще бъде взето и ползвано в контекста като params

        this.get('#/create', catalog.createTeamGet);
        this.post('#/create', (ctx) => { catalog.createTeamPost.call(ctx); });

        this.get('#/edit/:id', team.editTeamGet);
        this.post('#/edit/:id', (ctx) => { team.editTeamPost.call(ctx); }); 
        // ctx e контекста, който е равен на this.
        // Къдаравите скоби създават multiline функция
        // editTeamPost.call работи точно като editTeamPost.bind(), но освен това се самоизвиква.
        // editTeamPost.call предава контекста this на editTeamPost, а също може да предаде и параметри.
        // Ако не дадем контекст на .call, this ще е глобалният обект window.
        // Например:

        // CODE:
        // function printName(firstName, lastName){
        //     console.log(`${firstName} ${lastName}`);
        //     console.log(this);
        // }
        // printName.call({
        //     model: 'Samsung Galaxy S7',
        //     color: 'gold'
        // }, 'Ivan', 'Ivanov');

        // RESULT:
        // Ivan Ivanov
        // {
        //     model: 'Samsung Galaxy S7',
        //     color: 'gold'
        // }
    });

    app.run();                                // стартира приложението
});