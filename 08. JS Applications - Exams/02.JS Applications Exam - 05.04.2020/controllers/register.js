import * as data from '../scripts/data.js';

export default async function register() {

    this.partials = {
        header: await this.load('./partials/common/header.hbs'),
        footer: await this.load('./partials/common/footer.hbs')
    }

    this.partial('./partials/register.hbs', this.app.userData);
}

export async function registerPost() {
    const email = this.params.email;
    const password = this.params.password;
    const rePassword = this.params["rep-pass"];

    try {
        if (!email) {

            throw new Error('Email is required!');
        }

        if (password.length < 6) {

           throw new Error('Password should be at least 6 characters long!');
        }

        if (rePassword !== password) {

            throw new Error('Passwords do not match!');
        }

        const result = await data.register(email, password);

        if (result.hasOwnProperty('errorData')) {

            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect('#/login');

    } catch (error) {
        console.log(error);
    }
}
