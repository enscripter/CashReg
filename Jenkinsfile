#!/usr/bin/env groovy

pipeline {
    agent any

    stages {
        stage('Compile') {
            node {
                echo 'Comiling...'
                checkout scm
                stash 'everything'
                dir('src') {
                    sh 'dotnet build'
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Testing...'
                unstash 'everything'
                dir ('tests') {
                    sh 'dotnet test'
                }
            }
        }
        stage('publish') {
            echo 'Publishing...'
            parallel windowsx64: {
                publish('win10-x64')
            }, centos7x64: {
                publish('centos.7-x64')
            }, ubuntu1604x64: {
                publish('ubuntu.16.04-x64')
            }, linux: {
                publish('linux-x64')
            }, osx1012x64: {
                publish('osx.10.12-x64')
            }
        }
    }
    def publish(target) {
        node {
            unstash 'everything'
            dir('src') {
                sh "dotnet publish -r ${target}"
                archiveArtifacts "bin/Debug/netcoreapp2.0/${target}/publish/*.*"
            }
        }
    }
}