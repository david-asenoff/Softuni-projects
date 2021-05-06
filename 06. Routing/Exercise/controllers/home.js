export default async function() {            // целият файл е home controller, който се експортира като функция
                                             // this === Sammy.RenderContext, рендериране на темплейти
                                             // this съдържа verb, Където пише типа на метода (GET||POST||DELETE...)
    this.partials = {
        header: await this.load('./templates/common/header.hbs'),
        footer: await this.load('./templates/common/footer.hbs')
    };

    this.partial('./templates/home/home.hbs', this.app.userData); // прави render и swap едновременно
                                                                  // this.app.userData подава сесията на контролерите
}