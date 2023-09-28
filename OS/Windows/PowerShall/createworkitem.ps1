# az boards work-item create --title 'AddOn-GetAddresses -> ComGetAddresses' --type 'user story' --project QpcGateWare -o table
# az boards work-item relation add --id 3017 --target-id 3014  --relation-type parent -o table
# az boards work-item update --id 3016 --state Resolved -o table

param(
    # Work-Item's title
    [Parameter(Mandatory = $true)]
    [string]
    $title,

    # Work-Item type
    [Parameter(Mandatory = $true)]
    [string]
    $type,

    # Parant Id
    [Parameter(Mandatory = $true)]
    [int]
    $parentId = 0
)

$workItemId = az boards work-item create --title "$title" --type "$type" --project QpcGateWare --query id -o tsv

Write-Host "Work-Item Created with ID $workItemId"

if($parentId -gt 0)
{
    az boards work-item relation add --id $workItemId --target-id $parentId  --relation-type parent -o table
}

