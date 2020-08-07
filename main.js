const {app, BrowserWindow, Menu} = require('electron');

function createMenu() {
    let menuTemplate = [];
    let menuItems = Menu.buildFromTemplate(menuTemplate);
    Menu.setApplicationMenu(menuItems);
}

function main() {
    const win = new BrowserWindow({
        width: 350,
        height: 600,
        resizable: false
    });

    win.loadFile('index.html');
}

app.on('ready', () => {
    createMenu();
    main();
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit();
    }
});

app.on('activate', () => {
    if (BrowserWindow.getAllWindows() === 0) {
        main();
    }
});
