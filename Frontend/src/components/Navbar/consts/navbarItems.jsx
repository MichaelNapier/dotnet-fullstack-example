import PeopleIcon from '@mui/icons-material/People';
import ImageIcon from '@mui/icons-material/Image';
import PublicIcon from '@mui/icons-material/Public';
import SettingsEthernetIcon from '@mui/icons-material/SettingsEthernet';
import GroupsIcon from '@mui/icons-material/Groups';
import DnsIcon from '@mui/icons-material/Dns';

export const mainNavbarItems = [
    {
        id: 0,
        icon: <PeopleIcon />,
        label: 'Authentication',
        route: 'authentication',
    },
    {
        id: 1,
        icon: <DnsIcon />,
        label: 'Database',
        route: 'database',
    },
    {
        id: 2,
        icon: <ImageIcon />,
        label: 'Storage',
        route: 'storage',
    },
    {
        id: 3,
        icon: <SettingsEthernetIcon />,
        label: 'Functions',
        route: 'functions',
    },
    {
        id: 4,
        icon: <GroupsIcon />,
        label: 'Player',
        route: 'players',
    }, 
    {
        id: 5,
        icon: <PublicIcon />,
        label: 'Games',
        route: 'games',
    },
]