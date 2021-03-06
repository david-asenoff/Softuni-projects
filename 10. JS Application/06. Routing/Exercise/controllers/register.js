import { register } from '../scripts/data.js';

export default async function() {
                                             // this === Sammy.RenderContext, рендериране на темплейти
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        registerForm: await this.load('/templates/register/registerForm.hbs')
    };

    this.partial('./templates/register/registerPage.hbs');
}

export async function registerPost() {
    // Sammy.js ще прихване тази POST завка, и ще запише всички полета с таг "name=..." в нов обект.
    // В this.params може да достъпим обекта създаден от Sammy.js
    if (this.params.password !== this.params.repeatPassword) {
        alert(`Passwords do not match.`);
        return;
    }

    try {
        const result = await register(this.params.username, this.params.password);

        if (result.hasOwnProperty('errorData')) {
            const error = new Error();
            Object.assign(error, result);
            throw error;
        }

        this.redirect('#/login'); // ако всичко е валидно this.redirect ще пренасочи потребителя към login страницата.
    } catch (error) {
        console.error(error);
        alert(`Error: ${error.message}`); 
    }
}