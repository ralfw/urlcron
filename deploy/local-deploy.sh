#!/bin/bash
urlCronJobSource=$(awk 'BEGIN {FS=":="} $1 == "urlCron_JobSource" {print $2}' $SECRET_STORE)
export urlCronJobSource

sed s!'$urlCronJobSource'!$urlCronJobSource! < ../src/urlcron/urlcron/urlcron.config > ../bin/urlcron.config