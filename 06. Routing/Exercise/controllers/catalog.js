import { getTeams, createTeam, getTeamById} from '../scripts/data.js';
import * as notifications from '../scripts/notifications.js';

export async function teamCatalog() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/home');
        return;
    }
                                             // this === Sammy.RenderContext, рендериране на темплейти
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        team: await this.load('./templates/catalog/team.hbs')
    };

    const data = Object.assign({}, this.app.userData); // data е копие на userData
                                                       // Object.assign взема пропъртитата от userData и ги записва в празен обект,
                                                       // който присвоята на data
    data.teams = [];

    try {
        data.teams = await getTeams(token); // get data/teams

        if (data.teams.code) {
            throw data.teams;
        }
    } catch (error) {
        notifications.showNotification(error.message, 'error');  
    }

    this.partial('./templates/catalog/teamCatalog.hbs', data); // рендерира отборите на потребителя от data, 
                                                               // и позволява създаването на нов тийм.
}

export async function teamDetails() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/home');
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        teamMember: await this.load('./templates/catalog/teamMember.hbs'),
        teamControls: await this.load('./templates/catalog/teamControls.hbs')
    };

    let team = {};

    try {
        team = await getTeamById(this.params.id, token); // this.get('#/catalog/:id', catalog.teamDetails); от app.js
                                                         //:id ще бъде взето и ползвано в контекста като params
        if (team.code) {
            throw team;
        }
    } catch (error) {
        notifications.showNotification(error.message, 'error');
        this.redirect('#/catalog');
        return;
    }

    const data = {
        objectId: team.objectId,
        name: team.name,
        comment: team.comment,
        members: team.members.reduce((acc, curr) => {
            acc.push({username: curr.username});
            return acc;
        }, []),
        isAuthor: team.ownerId === localStorage.userId ? true : false,
        isOnTeam: team.members.some(m => m.objectId === localStorage.userId) ? true : false
    };

    Object.assign(data, this.app.userData);

    this.partial('./templates/catalog/details.hbs', data); // рендерира съдържанието, което е заредено по-горе в паметта.
}

export async function createTeamGet() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/login');
        return;
    }

    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        createForm: await this.load('./templates/create/createForm.hbs')
    };

    this.partial('./templates/create/createPage.hbs', this.app.userData);
}

export async function createTeamPost() {
    const token = localStorage.getItem('userToken');
    if (!token) {
        notifications.showNotification('User is not logged in', 'error');
        this.redirect('#/login');
        return;
    }

    if (this.app.userData.hasTeam) {
        notifications.showNotification('You already have a team.', 'error');
        this.redirect('#/catalog');
        return;
    }

    if (this.params.name === '') {
        notifications.showNotification('Team name is required', 'error');
        return;
    }

    const newTeam = {
        name: this.params.name,
        comment: this.params.comment
    };

    try {
        const createdTeam = await createTeam(newTeam, token);

        if (createdTeam.code) {
            throw createdTeam;
        }

        this.app.userData.hasTeam = true;
        notifications.showNotification('Team created!', 'info');

        this.redirect(`#/catalog/${createdTeam.objectId}`);
    } catch (error) {
        console.error(error);
        notifications.showNotification(error.message, 'error');
    }
}