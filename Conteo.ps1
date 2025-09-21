# Obtener fechas �nicas de commits (ordenadas)
$dates = git log --date=short --pretty=format:"%ad" | Sort-Object | Get-Unique

foreach ($date in $dates) {
    Write-Host "${date}: " -NoNewline

    # Obtener estad�sticas de l�neas agregadas/eliminadas para ese d�a
    $stats = git log --since="$date 00:00" --until="$date 23:59" --pretty=tformat: --numstat

    $added = 0
    $removed = 0

    foreach ($line in $stats) {
        if ($line -match "^\d+") {
            $cols = $line -split "`t"
            $added += [int]$cols[0]
            $removed += [int]$cols[1]
        }
    }

    Write-Host "agregadas: $added, eliminadas: $removed"
} 