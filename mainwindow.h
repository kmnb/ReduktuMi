#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QList>
#include "image.h"
#include <QFileDialog>

namespace Ui {
    class MainWindow;
}

class MainWindow : public QMainWindow {
    Q_OBJECT
public:
    MainWindow(QWidget *parent = 0);
    ~MainWindow();

protected:
    void changeEvent(QEvent *e);

private :
    Ui::MainWindow *ui;
    QList<Image> imagesList();

public slots :
    void addImages();
    void removeImages();
    void clearList();
};

#endif // MAINWINDOW_H
