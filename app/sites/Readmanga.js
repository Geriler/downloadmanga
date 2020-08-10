const Site = require('./Site');

/**
 * Класс для скачивания манги с сайта readmanga
 */
class Readmanga extends Site {
    _link = 'https://readmanga.live/';
    _name_manga = '';
    _num_volume = 1;
    _num_chapter = 0;
    _create_pdf = false;
    _remove_images = false;
    _download_all = false;

    constructor(app_path, name_manga, num_volume, num_chapter, create_pdf, remove_images, download_all) {
        super(app_path);
        this._name_manga = name_manga;
        this._num_volume = num_volume;
        this._num_chapter = num_chapter;
        this._create_pdf = create_pdf;
        this._remove_images = remove_images;
        this._download_all = download_all;
    }

    getLinkToManga() {
        return this._link + this._name_manga;
    }

    downloadAll() {
        console.log('Download all for Readmanga');
    }
}

module.exports = Readmanga;
