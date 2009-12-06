#include "mainwindow.h"
#include "ui_mainwindow.h"


MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    connect(this->ui->pushButton_Add, SIGNAL(clicked()), this, SLOT(addImages()));
    connect(this->ui->pushButton_Remove, SIGNAL(clicked()), this, SLOT(removeImages()));
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::changeEvent(QEvent *e)
{
    QMainWindow::changeEvent(e);
    switch (e->type()) {
    case QEvent::LanguageChange:
        ui->retranslateUi(this);
        break;
    default:
        break;
    }
}

void MainWindow::addImages()
{
    QFileDialog dialog(this);
    dialog.setFileMode(QFileDialog::ExistingFiles);
    dialog.setNameFilter(tr("Images (*.png *.xpm *.jpg)"));
    dialog.setViewMode(QFileDialog::List);
    dialog.setDirectory(QDir::home());

    QStringList fileNames;
    if (dialog.exec())
    {
         fileNames = dialog.selectedFiles();
    }

    QFile *file;
    foreach(QString filePath, fileNames)
    {
        file = new QFile(filePath);
    }
    file->~QFile();
}

void MainWindow::removeImages()
{

}

void MainWindow::clearList()
{

}
