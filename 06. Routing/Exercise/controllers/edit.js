export default async function() {
                                             // this === Sammy.RenderContext, рендериране на темплейти
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs'),
        editForm: await this.load('./templates/edit/editForm.hbs')
    };

    this.partial('./templates/edit/editPage.hbs', this.app.userData);
}