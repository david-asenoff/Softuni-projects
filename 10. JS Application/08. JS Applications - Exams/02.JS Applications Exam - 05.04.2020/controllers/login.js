import * as data from '../scripts/data.js';

export default async function login() {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    this.partial('./partials/login.hbs', this.app.userData);
}

export async function loginPost() {

    const email = this.params.email;
    const password = this.params.password;

    const emailInput = document.getElementById('email');
    const passwordInput = document.getElementById('login-pass');

    try {

        if (email.length == 0) {

            throw new Error('Username is required!');
        }

        if (password.length == 0) {

            throw new Error('Password is required!');
        }

        const result = await data.login(email, password);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.app.userData.isLoggedIn = true;
        this.app.userData.userId = result.objectId;
        this.app.userData.email = result.email;
        this.app.userData.userToken = result['user-token'];

        localStorage.setItem('userId', result.objectId);
        localStorage.setItem('username', result.username);
        localStorage.setItem('email', result.email);
        localStorage.setItem('userToken', result['user-token']);

        emailInput.value = '';
        passwordInput.value = '';
        console.log(this.app.userData.isLoggedIn);
        this.redirect('#/home');

    } catch (error) {
        console.log(error);
    }


}





