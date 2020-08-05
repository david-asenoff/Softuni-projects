const applicationID = '42F3BF79-A842-320D-FFD8-3853C995B800';
const restAPIkey = '23056459-8F0D-4A24-BE5D-4E766AC35CD5';

function host(endpoint) {
    return `https://api.backendless.com/${applicationID}/${restAPIkey}/${endpoint}`;
}

const endpoints = {
    REGISTER: 'users/register',
    LOGIN: 'users/login',
    LOGOUT: 'users/logout',
    TEAMS: 'data/teams',
    USERS: 'data/Users',
    MEMBERS: '?loadRelations=members'
};

export async function register(user) { // default identity трябва да се предаде чрез body
    return (await fetch(host(endpoints.REGISTER), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user) // login (username) and password are required by DB (not null)
    })).json();
}

export async function login(user) {
    return (await fetch(host(endpoints.LOGIN), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })).json();
}

export async function logout(token) {
    return await fetch(host(endpoints.LOGOUT), {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        }
    });
}

export async function createTeam(team, token) {
    const createdTeam = await (await fetch(host(endpoints.TEAMS), {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(team)
    })).json();

    if (createdTeam.code) {
        return createdTeam;
    }

    const teamId = createdTeam.objectId;
    const userId = localStorage.getItem('userId'); // в local storage се съхранява потребителската сесия в браузъра

    const teamMembers = await (await fetch(host(endpoints.TEAMS + `/${teamId}/members`), {
        method: 'POST',
        headers: {
            'Content-type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify([userId])
    })).json();

    if (teamMembers.code) {
        return teamMembers;
    }

    await (await fetch(host(endpoints.TEAMS + `/${userId}`), {
        method: 'PUT',
        headers: {
            'Content-type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify({
            teamId: teamId
        })
    })).json();

    return createdTeam;
}

export async function editTeam(editedTeam, id, token) {
    return await (await fetch(host(endpoints.TEAMS + '/' + id + endpoints.MEMBERS), {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'user-token': token
        },
        body: JSON.stringify(editedTeam)
    })).json();
}

export async function getTeamById(id, token) {
    // this.get('#/catalog/:id', catalog.teamDetails); 
    // :id ще бъде взето и ползвано в контекста като params
    // token идва от localStorage. Подадено от teamDetails, catalog controller
    return await (await fetch(host(endpoints.TEAMS + '/' + id), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    })).json();
}

export async function getTeams(token) {
    return await (await fetch(host(endpoints.TEAMS), {
        method: 'GET',
        headers: {
            'user-token': token
        }
    })).json();
}