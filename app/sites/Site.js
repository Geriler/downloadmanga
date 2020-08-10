const fs = require('fs');

/**
 * Абстрактный класс Site
 */
class Site {
    static _app_path = '';

    constructor(app_path) {
        if (new.target === Site) {
            throw new TypeError("Cannot construct Site instances directly");
        }
        Site._app_path = app_path;
    }

    /**
     * Абстрактные методы
     *
     * getLinkToManga - получает ссылку на мангу
     * downloadAll - скачивает всю мангу с сайта
     */
    getLinkToManga() { throw new Error('You have to implement the method getLinkToManga!'); }
    downloadAll() { throw new Error('You have to implement the method downloadAll!'); }

    /**
     * Конечные методы
     *
     * createDirectoryItNotExists - создает директорию, если она не существует
     * createPdf - создает PDF файл с мангой
     * removeImages - удаляет все изображения
     */
    static createDirectoryIfNotExists(path) {
        let dir_manga = this._app_path + '/' + path;
        if (!fs.existsSync(dir_manga)) this.fs.mkdir(dir_manga, function () {
            console.log('Directory "' + path + '" created');
        });
    }
    static createPdf() {}
    static removeImages() {}

    download() {
        if (this._download_all) this.downloadAll();
        if (this._create_pdf) Site.createPdf();
        if (this._remove_images) Site.removeImages();
    }
}

module.exports = Site;
