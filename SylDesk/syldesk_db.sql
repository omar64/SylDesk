-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 07-06-2018 a las 22:07:16
-- Versión del servidor: 10.1.21-MariaDB
-- Versión de PHP: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `syldesk_db`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `especies`
--

CREATE TABLE `especies` (
  `id` int(11) NOT NULL,
  `nombrecientifico` varchar(40) NOT NULL,
  `nombrecomun` varchar(40) NOT NULL,
  `familia` varchar(40) NOT NULL,
  `formadevida` varchar(40) NOT NULL,
  `genero` varchar(40) NOT NULL,
  `categoriadenorma` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

--
-- Volcado de datos para la tabla `especies`
--

INSERT INTO `especies` (`id`, `nombrecientifico`, `nombrecomun`, `familia`, `formadevida`, `genero`, `categoriadenorma`) VALUES
(363, 'Acacia angustissima', 'K\'antemo', 'Leguminosae', 'Árbol', 'Acacia', ''),
(364, 'Acacia collinsii', 'Subin che\'', 'Leguminosae', 'Árbol', 'Acacia', ''),
(365, 'Acacia cornigera', 'Cornezuelo subin', 'Leguminosae', 'Árbol', 'Acacia', ''),
(366, 'Acacia dolichostachya', 'K\'an tsalam', 'Leguminosae', 'Árbol', 'Acacia', ''),
(367, 'Acacia gaumeri', 'Katzim', 'Leguminosae', 'Árbol', 'Acacia', ''),
(368, 'Acacia pennatula', 'Ch\'i\' may', 'Leguminosae', 'Árbol', 'Acacia', ''),
(369, 'Acalypha alopecuroides', 'Cola de gato', 'Euphorbiaceae', 'Herbácea', 'Acalypha', ''),
(370, 'Acalypha macrostachya', 'Moco de pavo', 'Euphorbiaceae', 'Arbusto', 'Acalypha', ''),
(371, 'Acoelorrhaphe wrightii', 'Tasisite', 'Arecaceae', 'Palma', 'Acoelorrhaphe', ''),
(372, 'Acrostichum danaeifolium', 'Helecho de manglar', 'Pteridaceae', 'Helecho', 'Acrostichum', ''),
(373, 'Adenocalymma inundatum', 'Bejuco tres hojas', 'Bignoniaceae', 'Bejuco', 'Adenocalymma', ''),
(374, 'Agave angustifolia var. Angustifolia', 'Chelem', 'Asparagaceae', 'Acaulescente', 'Agave', ''),
(375, 'Albizia tomentosa', 'Sak píich', 'Leguminosae', 'Árbol', 'Albizia', ''),
(376, 'Allophylus camptostachys', 'Allophylus', 'Sapindaceae', 'Árbol', 'Allophylus', ''),
(377, 'Allophylus cominia', 'Sak pixoy', 'Sapindaceae', 'Árbol', 'Allophylus', ''),
(378, 'Alseis yucatanensis', 'Haasche\'', 'Rubiaceae', 'Árbol', 'Alseis', ''),
(379, 'Alternanthera flavescens', 'Amor seco del monte', 'Amaranthaceae', 'Herbácea', 'Alternanthera', ''),
(380, 'Alvaradoa amorphoides', 'Palo de hormiga', 'Simaroubaceae', 'Árbol', 'Alvaradoa', ''),
(381, 'Ambrosia hispida', 'Margarita de mar', 'Asteraceae', 'Herbácea', 'Ambrosia', ''),
(382, 'Amphilophium crucigerum', 'Bejuco seis hojas', 'Bignoniaceae', 'Bejuco', 'Amphilophium', ''),
(383, 'Amphilophium paniculatum', 'Malo\'ob aak\'', 'Bignoniaceae', 'Bejuco', 'Amphilophium', ''),
(384, 'Amphitecna latifolia', 'Jicarilla', 'Bignoniaceae', 'Árbol', 'Amphitecna', ''),
(385, 'Amyris elemifera', 'Palo igaso', 'Rutaceae', 'Árbol', 'Amyris', ''),
(386, 'Amyris sylvatica', 'K\'an yuuk', 'Rutaceae', 'Árbol', 'Amyris', ''),
(387, 'Andira inermis', 'Choluul', 'Leguminosae', 'Árbol', 'Andira', ''),
(388, 'Andropogon glomeratus', 'Ch\'it su\'uk', 'Poaceae', 'Herbácea', 'Andropogon', ''),
(389, 'Annona glabra', 'Palo de corcho', 'Annonaceae', 'Árbol', 'Annona', ''),
(390, 'Annona primigenia', 'Anonillo', 'Annonaceae', 'Árbol', 'Annona', ''),
(391, 'Annona purpurea', 'Chak oop', 'Annonaceae', 'Árbol', 'Annona', ''),
(392, 'Annona squamosa', 'Saramuyo', 'Annonaceae', 'Árbol', 'Annona', ''),
(393, 'Anthurium schlechtendalii ssp. Schlechte', 'Bobtun', 'Araceae', 'Epífita', 'Anthurium', ''),
(394, 'Aphelandra scabra', 'Chak nal', 'Acanthaceae', 'Arbusto', 'Aphelandra', ''),
(395, 'Apoplanesia paniculata', 'Chulúul', 'Leguminosae', 'Árbol', 'Apoplanesia', ''),
(396, 'Ardisia escallonioides', 'Pimienta de monte', 'Primulaceae', 'Arbusto', 'Ardisia', ''),
(397, 'Ardisia revoluta', 'Ardisia', 'Primulaceae', 'Árbol', 'Ardisia', ''),
(398, 'Aristolochia trilobata', 'Wahk´o´', 'Aristolochiaceae', 'Bejuco', 'Aristolochia', ''),
(399, 'Arrabidaea floribunda', 'Sak aak\'', 'Bignoniaceae', 'Trepadora', 'Arrabidaea', ''),
(400, 'Arrabidaea patellifera', 'Bilin kak', 'Bignoniaceae', 'Bejuco', 'Arrabidaea', ''),
(401, 'Arrabidaea podopogon', 'sak ak\'', 'Bignoniaceae', 'Trepadora', 'Arrabidaea', ''),
(402, 'Asemnantha pubescens', 'Kanchak che\'', 'Rubiaceae', 'Arbusto', 'Asemnantha', ''),
(403, 'Aspidosperma megalocarpon', 'Peech ma\'ax', 'Apocynaceae', 'Árbol', 'Aspidosperma', ''),
(404, 'Aspidosperma spruceanum', 'Bayo', 'Apocynaceae', 'Herbácea', 'Aspidosperma', ''),
(405, 'Astrocasia tremula', 'Mejen piix t\'oon', 'Phyllanthaceae', 'Árbol o arbusto', 'Astrocasia', ''),
(406, 'Astronium graveolens', 'K\'ulimche\'', 'Anacardiaceae', 'Árbol', 'Astronium', ''),
(407, 'Ateleia gummifera', 'Corrocho', 'Leguminosae', 'Árbol o arbusto', 'Ateleia', ''),
(408, 'Attilaea abalak', 'no tiene', 'Anacardiaceae', 'Árbol', 'Attilaea', ''),
(409, 'Bauhinia divaricata', 'Maay wakax', 'Leguminosae', 'Árbol o arbusto', 'Bauhinia', ''),
(410, 'Bauhinia jenningsii', 'Tsimin', 'Leguminosae', 'Arbusto', 'Bauhinia', ''),
(411, 'Beaucarnea pliabilis', 'Despeinada', 'Asparagaceae', 'Árbol', 'Beaucarnea', ''),
(412, 'Bignonia potosina', 'Ek\'k\'ixil', 'Bignoniaceae', 'Bejuco', 'Bignonia', ''),
(413, 'Blomia prisca', 'Sibul', 'Sapindaceae', 'Árbol', 'Blomia', ''),
(414, 'Bonellia albiflora', 'Bonellia', 'Primulaceae', 'Árbol', 'Bonellia', ''),
(415, 'Bonellia macrocarpa', 'Ya\'ax kiix le\' che\'', 'Primulaceae', 'Árbol', 'Bonellia', ''),
(416, 'Bourreria huanita', 'Bakal-ché', 'Boraginaceae', 'Árbol', 'Bourreria', ''),
(417, 'Bravaisia berlandieriana', 'Hulub', 'Acanthaceae', 'Arbusto', 'Bravaisia', ''),
(418, 'Bromelia karatas', 'Piñuela', 'Bromeliaceae', 'Herbácea', 'Bromelia', ''),
(419, 'Bromelia pinguin', 'Ch\'om', 'Bromeliaceae', 'Herbácea', 'Bromelia', ''),
(420, 'Bromelia alsodes', 'Bromelia', 'Bromeliaceae', 'Herbácea', 'Bromelia', ''),
(421, 'Brosimum alicastrum', 'Ox', 'Moraceae', 'Árbol', 'Brosimum', ''),
(422, 'Bucida buceras', 'no tiene', 'Combretaceae', 'Árbol', 'Bucida', ''),
(423, 'Bunchosia swartziana', 'Sip che\'', 'Malpighiaceae', 'Arbusto', 'Bunchosia', ''),
(424, 'Bursera simaruba', 'Chacah', 'Burseraceae', 'Árbol', 'Bursera', ''),
(425, 'Byrsonima bucidifolia', 'Sakpah', 'Malpighiaceae', 'Árbol', 'Byrsonima', ''),
(426, 'Byrsonima crassifolia', 'Chí', 'Malpighiaceae', 'Árbol', 'Byrsonima', ''),
(427, 'Byttneria aculeata', 'Rabo de iguana', 'Malvaceae', 'Bejuco', 'Byttneria', ''),
(428, 'Caesalpinia gaumeri', 'Kitamche', 'Leguminosae', 'Árbol', 'Caesalpinia', ''),
(429, 'Caesalpinia mollis', 'Chakte\' viga', 'Leguminosae', 'Árbol', 'Caesalpinia', ''),
(430, 'Caesalpinia vesicaria', 'Chintok', 'Leguminosae', 'Árbol o arbusto', 'Caesalpinia', ''),
(431, 'Caesalpinia violacea', 'Chacte\'', 'Leguminosae', 'Árbol', 'Caesalpinia', ''),
(432, 'Caesalpinia yucatanensis', 'Takinche', 'Leguminosae', 'Árbol', 'Caesalpinia', ''),
(433, 'Callicarpa acuminata', 'Pukin', 'Lamiaceae', 'Arbusto', 'Callicarpa', ''),
(434, 'Calyptranthes millspaughii', 'Pimientillo', 'Myrtaceae', 'Árbol o arbusto', 'Calyptranthes', ''),
(435, 'Calyptranthes pallens', 'Chaknii', 'Myrtaceae', 'Árbol o arbusto', 'Calyptranthes', ''),
(436, 'Cameraria latifolia', 'Cheechen blanco', 'Apocynaceae', 'Árbol o arbusto', 'Cameraria', ''),
(437, 'Canavalia brasiliensis', 'Canavalia', 'Leguminosae', 'Bejuco', 'Canavalia', ''),
(438, 'Canavalia rosea', 'Frijolillo', 'Leguminosae', 'Bejuco', 'Canavalia', ''),
(439, 'Canella winterana', 'Canela', 'Cannaceae', 'Árbol o arbusto', 'Canella', ''),
(440, 'Cardiospermum corindum', 'Wayuum aak\'', 'Sapindaceae', 'Bejuco', 'Cardiospermum', ''),
(441, 'Cardiospermum grandiflorum', 'Tomatillo verde', 'Sapindaceae', 'Trepadora', 'Cardiospermum', ''),
(442, 'Carica mexicana', 'Papaya', 'Caricaceae', 'Árbol', 'Carica', ''),
(443, 'Cascabela gaumeri', 'Akits', 'Apocynaceae', 'Árbol', 'Cascabela', ''),
(444, 'Casearia aculeata', 'Ts\'iuche\'', 'Salicaceae', 'Árbol o arbusto', 'Casearia', ''),
(445, 'Casearia corymbosa', 'Cascarillo', 'Salicaceae', 'Árbol o arbusto', 'Casearia', ''),
(446, 'Casimiroa edulis', 'Sapote blanco', 'Rutaceae', 'Árbol', 'Casimiroa', ''),
(447, 'Casimiroa tetrameria', 'Yuuy', 'Rutaceae', 'Árbol', 'Casimiroa', ''),
(448, 'Cassine xylocarpa', 'Chechem blanco', 'Celastraceae', 'Árbol', 'Cassine', ''),
(449, 'Cassipourea elliptica', 'Ta\'abché', 'Erythroxylaceae', 'Árbol o arbusto', 'Cassipourea', ''),
(450, 'Casuarina equisetifolia', 'Pino de playa', 'Casuarinaceae', 'Árbol', 'Casuarina', ''),
(451, 'Cecropia peltata', 'Guarumbo', 'Urticaceae', 'Árbol', 'Cecropia', ''),
(452, 'Cedrela odorata', 'Cedro', 'Meliaceae', 'Árbol', 'Cedrela', ''),
(453, 'Ceiba aesculifolia', 'Pochote', 'Malvaceae', 'Árbol', 'Ceiba', ''),
(454, 'Celtis iguanaea', 'Muk', 'Cannabaceae', 'Árbol o arbusto', 'Celtis', ''),
(455, 'Cenchrus echinatus', 'Zu\'uuk K\'ix', 'Poaceae', 'Herbácea', 'Cenchrus', ''),
(456, 'Centrosema macrocarpum', 'Centrosema', 'Leguminosae', 'Bejuco', 'Centrosema', ''),
(457, 'Centrosema molle', 'Tres hojas', 'Leguminosae', 'Bejuco', 'Centrosema', ''),
(458, 'Chamaedorea seifrizii', 'Xiat', 'Arecaceae', 'Palma', 'Chamaedorea', ''),
(459, 'Chiococca alba', 'Tabaquillo', 'Rubiaceae', 'Bejuco', 'Chiococca', ''),
(460, 'Chloroleucon mangense', 'Ya\' ax eek\'', 'Leguminosae', 'Árbol o arbusto', 'Chloroleucon', ''),
(461, 'Chrysobalanus icaco', 'Icaco', 'Chrysobalanaceae', 'Árbol o arbusto', 'Chrysobalanus', ''),
(462, 'Chrysophyllum mexicanum', 'Caimito', 'Sapotaceae', 'Árbol', 'Chrysophyllum', ''),
(463, 'Cissus alata', 'X-uvas-xim', 'Vitaceae', 'Bejuco', 'Cissus', ''),
(464, 'Cissus gossypiifolia', 'Juan mecate', 'Vitaceae', 'Bejuco', 'Cissus', ''),
(465, 'Cissus trifoliata', 'Bejuco bbolon tib ib', 'Vitaceae', 'Bejuco', 'Cissus', ''),
(466, 'Cissus verticillata', 'Bejuco Cissus', 'Vitaceae', 'Bejuco', 'Cissus', ''),
(467, 'Cladium jamaicense', 'Jol che\'', 'Cyperaceae', 'Herbácea', 'Cladium', ''),
(468, 'Clematis dioica', 'Barbas de chivo', 'Ranunculaceae', 'Bejuco', 'Clematis', ''),
(469, 'Clusia flava', 'Chumuup', 'Clusiaceae', 'Árbol o arbusto', 'Clusia', ''),
(470, 'Cnidoscolus aconitifolius', 'Chaya', 'Euphorbiaceae', 'Árbol', 'Cnidoscolus', ''),
(471, 'Coccoloba acapulcensis', 'Toyub', 'Polygonaceae', 'Árbol o arbusto', 'Coccoloba', ''),
(472, 'Coccoloba acuminata', 'Coccoloba', 'Polygonaceae', 'Árbol o arbusto', 'Coccoloba', ''),
(473, 'Coccoloba barbadensis', 'Boob che', 'Polygonaceae', 'Árbol', 'Coccoloba', ''),
(474, 'Coccoloba cozumelensis', 'Sak boob', 'Polygonaceae', 'Árbol o arbusto', 'Coccoloba', ''),
(475, 'Coccoloba diversifolia', 'Chich bob', 'Polygonaceae', 'Árbol o arbusto', 'Coccoloba', ''),
(476, 'Coccoloba spicata', 'Boob', 'Polygonaceae', 'Árbol', 'Coccoloba', ''),
(477, 'Coccoloba uvifera', 'Uva de mar', 'Polygonaceae', 'Árbol', 'Coccoloba', ''),
(478, 'Coccothrinax readii', 'Palma nacax', 'Arecaceae', 'Palma', 'Coccothrinax', ''),
(479, 'Cochlospermum vitifolium', 'Chuum', 'Bixaceae', 'Árbol', 'Cochlospermum', ''),
(480, 'Cocos nucifera', 'Palma Cocotero', 'Arecaceae', 'Palma', 'Cocos', ''),
(481, 'Colubrina elliptica', 'Sak\'nache', 'Rhamnaceae', 'Árbol', 'Colubrina', ''),
(482, 'Colubrina heteroneura', 'Espino del diablo', 'Rhamnaceae', 'Árbol o arbusto', 'Colubrina', ''),
(483, 'Conocarpus erectus', 'Mangle botoncillo', 'Combretaceae', 'Árbol', 'Conocarpus', ''),
(484, 'Cordia alliodora', 'Bojón prieto', 'Boraginaceae', 'Árbol', 'Cordia', ''),
(485, 'Cordia dodecandra', 'Siricote', 'Boraginaceae', 'Árbol', 'Cordia', ''),
(486, 'Cordia gerascanthus', 'Bojon', 'Boraginaceae', 'Árbol', 'Cordia', ''),
(487, 'Cordia sebestena', 'Siricote de playa', 'Boraginaceae', 'Árbol', 'Cordia', ''),
(488, 'Couepia polyandra', 'Guayo', 'Chrysobalanaceae', 'Árbol', 'Couepia', ''),
(489, 'Critonia daleoides', 'Tok\'kabal', 'Asteraceae', 'Arbusto', 'Critonia', ''),
(490, 'Crossopetalum gentle', 'Ta\'ts\'i', 'Celastraceae', 'Arbusto', 'Crossopetalum', ''),
(491, 'Crossopetalum parviflorum', 'Pinta uña', 'Celastraceae', 'Árbol o arbusto', 'Crossopetalum', ''),
(492, 'Crossopetalum rhacoma', 'Kabal muk', 'Celastraceae', 'Arbusto', 'Crossopetalum', ''),
(493, 'Crotalaria longirostrata', 'Chipilin', 'Leguminosae', 'Arbusto', 'Crotalaria', ''),
(494, 'Croton arboreus', 'Pak che\'', 'Euphorbiaceae', 'Arbusto', 'Croton', ''),
(495, 'Croton flavens', 'Ek\'balam', 'Euphorbiaceae', 'Arbusto', 'Croton', ''),
(496, 'Croton niveus', 'Chulche’', 'Euphorbiaceae', 'Árbol o arbusto', 'Croton', ''),
(497, 'Croton reflexifolius', 'Perescuts', 'Euphorbiaceae', 'Árbol', 'Croton', ''),
(498, 'Cupania dentata', 'Sak poom', 'Sapindaceae', 'Árbol', 'Cupania', ''),
(499, 'Cupania glabra', 'Rabo de cojolite', 'Sapindaceae', 'Árbol o arbusto', 'Cupania', ''),
(500, 'Cuscuta americana', 'Cuscuta', 'Convolvulaceae', 'Herbácea', 'Cuscuta', ''),
(501, 'Cydista aequinoctalis', 'Ak\'xux', 'Bignoniaceae', 'Bejuco', 'Cydista', ''),
(502, 'Cydista diversifolia', 'Anilkab', 'Bignoniaceae', 'Bejuco', 'Cydista', ''),
(503, 'Cynodon dactylon', 'Zacate bermuda', 'Poaceae', 'Herbácea', 'Cynodon', ''),
(504, 'Cynophalla verrucosa', 'Silil', 'Capparaceae', 'Árbol o arbusto', 'Cynophalla', ''),
(505, 'Cyperus hermaphroditus', 'Zacate tule', 'Cyperaceae', 'Herbácea', 'Cyperus', ''),
(506, 'Cyrtopodium macrobulbon', 'Cañuela de playa', 'Orchidaceae', 'Herbácea', 'Cyrtopodium', ''),
(507, 'Dalbergia glabra', 'Ahmuk', 'Leguminosae', 'Bejuco', 'Dalbergia', ''),
(508, 'Dendropanax arboreus', 'Sak chakaj', 'Araliaceae', 'Árbol', 'Dendropanax', ''),
(509, 'Dialium guianense', 'Guapaque', 'Leguminosae', 'Árbol', 'Dialium', ''),
(510, 'Dioscorea alata', 'Makal, Bej de agua', 'Dioscoreaceae', 'Bejuco', 'Dioscorea', ''),
(511, 'Dioscorea floribunda', 'Makal k’uuch', 'Dioscoreaceae', 'Trepadora', 'Dioscorea', ''),
(512, 'Dioscorea polygonoides', 'Cheen cha', 'Dioscoreaceae', 'Trepadora', 'Dioscorea', ''),
(513, 'Diospyros anisandra', 'K´aakalche', 'Ebenaceae', 'Árbol o arbusto', 'Diospyros', ''),
(514, 'Diospyros digyna', 'Ta\'uch', 'Ebenaceae', 'Árbol', 'Diospyros', ''),
(515, 'Diospyros tetrasperma', 'K\'ab che\'', 'Ebenaceae', 'Árbol o arbusto', 'Diospyros', ''),
(516, 'Diospyros verae-crucis', 'Uchul che\'', 'Ebenaceae', 'Árbol o arbusto', 'Diospyros', ''),
(517, 'Diospyros yucatanensis', 'Diospyros', 'Ebenaceae', 'Árbol o arbusto', 'Diospyros', ''),
(518, 'Diospyros yucatanensis ssp. Longipedicel', 'U chul che', 'Ebenaceae', 'Árbol o arbusto', 'Diospyros', ''),
(519, 'Diphysa carthagenensis', 'Tsu\'uts\'uk', 'Leguminosae', 'Árbol o arbusto', 'Diphysa', ''),
(520, 'Distichlis spicata', 'Zacate salado', 'Poaceae', 'Herbácea', 'Distichlis', ''),
(521, 'Drypetes lateriflora', 'Ekulub', 'Putranjivaceae', 'Árbol', 'Drypetes', ''),
(522, 'Echites umbellatus', 'Chak kaanel', 'Apocynaceae', 'Bejuco', 'Echites', ''),
(523, 'Elaeodendron xylocarpum', 'Chooch kitam', 'Celastraceae', 'Árbol o arbusto', 'Elaeodendron', ''),
(524, 'Eleocharis cellulosa', 'Juncia', 'Cyperaceae', 'Herbácea', 'Eleocharis', ''),
(525, 'Encyclia adenocarpa', 'Orquídea', 'Orchidaceae', 'Epífita', 'Encyclia', ''),
(526, 'Ernodea littoralis', 'Trepadora dorada', 'Rubiaceae', 'Arbusto', 'Ernodea', ''),
(527, 'Erythrina standleyana', 'Chakmolche\'', 'Leguminosae', 'Árbol o arbusto', 'Erythrina', ''),
(528, 'Erythroxylum areolatum', 'Cascarillo delgado', 'Erythroxylaceae', 'Árbol o arbusto', 'Erythroxylum', ''),
(529, 'Erythroxylum rotundifolium', 'Xic-che', 'Erythroxylaceae', 'Árbol o arbusto', 'Erythroxylum', ''),
(530, 'Esenbeckia pentaphylla', 'Naranche', 'Rutaceae', 'Árbol', 'Esenbeckia', ''),
(531, 'Eugenia axillaris', 'Granada cimarrona', 'Myrtaceae', 'Árbol', 'Eugenia', ''),
(532, 'Eugenia biflora', 'Pichiche', 'Myrtaceae', 'Arbusto', 'Eugenia', ''),
(533, 'Eugenia capuli', 'Árbol de arrayán', 'Myrtaceae', 'Árbol o arbusto', 'Eugenia', ''),
(534, 'Eugenia foetida', 'Sak loob', 'Myrtaceae', 'Árbol o arbusto', 'Eugenia', ''),
(535, 'Eugenia karwinskyana', 'Saklob', 'Myrtaceae', 'Árbol o arbusto', 'Eugenia', ''),
(536, 'Eugenia rhombea', 'Guayabita', 'Myrtaceae', 'Árbol o arbusto', 'Eugenia', ''),
(537, 'Eugenia trikii', 'Escobeta', 'Myrtaceae', 'Árbol o arbusto', 'Eugenia', ''),
(538, 'Eugenia winzerlingii', 'Botoncillo', 'Myrtaceae', 'Árbol o arbusto', 'Eugenia', ''),
(539, 'Eupatorium albicaule', 'Sak tok\'aban', 'Asteraceae', 'Árbol o arbusto', 'Eupatorium', ''),
(540, 'Euphorbia mesembryanthemifolia', 'Sak iits', 'Euphorbiaceae', 'Arbusto', 'Euphorbia', ''),
(541, 'Exostema mexicanum', 'Sabak che', 'Rubiaceae', 'Árbol', 'Exostema', ''),
(542, 'Exothea diphylla', 'Wayuun koox', 'Sapindaceae', 'Árbol', 'Exothea', ''),
(543, 'Exothea paniculata', 'Árbol sol', 'Sapindaceae', 'Árbol o arbusto', 'Exothea', ''),
(544, 'Ficus cotinifolia', 'Álamo', 'Moraceae', 'Árbol', 'Ficus', ''),
(545, 'Ficus crassinervia', 'Higo', 'Moraceae', 'Árbol', 'Ficus', ''),
(546, 'Ficus crocata', 'Higo mono', 'Moraceae', 'Árbol', 'Ficus', ''),
(547, 'Ficus maxima', 'Akúun', 'Moraceae', 'Árbol', 'Ficus', ''),
(548, 'Ficus obtusifolia', 'Sak\' awaj', 'Moraceae', 'Árbol', 'Ficus', ''),
(549, 'Ficus pertusa', 'Amatillo', 'Moraceae', 'Árbol o arbusto', 'Ficus', ''),
(550, 'Ficus tecolutensis', 'Mata palo', 'Moraceae', 'Árbol o arbusto', 'Ficus', ''),
(551, 'Forchhammeria trifoliata', 'Tres marías', 'Capparaceae', 'Árbol', 'Forchhammeria', ''),
(552, 'Garcinia intermedia', 'Nikte\'', 'Clusiaceae', 'Árbol', 'Garcinia', ''),
(553, 'Gliricidia sepium', 'Cocoite negro', 'Leguminosae', 'Árbol', 'Gliricidia', ''),
(554, 'Godmania aesculifolia', 'Lokop', 'Bignoniaceae', 'Árbol', 'Godmania', ''),
(555, 'Guaiacum sanctum', 'Guayacán', 'Zygophyllaceae', 'Árbol o arbusto', 'Guaiacum', ''),
(556, 'Guarea glabra', 'Cedrillo', 'Meliaceae', 'Árbol', 'Guarea', ''),
(557, 'Guazuma ulmifolia', 'Guazima', 'Malvaceae', 'Árbol', 'Guazuma', ''),
(558, 'Guettarda combsii', 'Tasta\'ab', 'Rubiaceae', 'Árbol', 'Guettarda', ''),
(559, 'Guettarda elliptica', 'Box tasta\'a', 'Rubiaceae', 'Árbol o arbusto', 'Guettarda', ''),
(560, 'Gymnanthes lucida', 'Yayté', 'Euphorbiaceae', 'Árbol', 'Gymnanthes', ''),
(561, 'Gymnopodium floribundum', 'Ts\'iits\'ilche\'', 'Polygonaceae', 'Árbol o arbusto', 'Gymnopodium', ''),
(562, 'Hampea trilobata', 'Ho\'ol', 'Malvaceae', 'Árbol o arbusto', 'Hampea', ''),
(563, 'Heliconia latispatha', 'Platanillo', 'Heliconiaceae', 'Herbácea', 'Heliconia', ''),
(564, 'Helicteres baruensis', 'Suput', 'Malvaceae', 'Arbusto', 'Helicteres', ''),
(565, 'Heteropteris beecheyana', 'Chakanikab', 'Malpighiaceae', 'Bejuco', 'Heteropteris', ''),
(566, 'Hippomane mancinella', 'Manzanillo de playa', 'Euphorbiaceae', 'Árbol', 'Hippomane', ''),
(567, 'Hymenocallis littoralis', 'Lirio de playa', 'Amaryllidaceae', 'Herbácea', 'Hymenocallis', ''),
(568, 'Ipomoea pes-caprae', 'Riñonina', 'Convolvulaceae', 'Trepadora', 'Ipomoea', ''),
(569, 'Ipomoea splendor-sylvae', 'Isaak\'il', 'Convolvulaceae', 'Bejuco', 'Ipomoea', ''),
(570, 'Jacquinia arborea', 'Jaquinia', 'Primulaceae', 'Árbol o arbusto', 'Jacquinia', ''),
(571, 'Jatropha gaumeri', 'Pomolche', 'Euphorbiaceae', 'Árbol', 'Jatropha', ''),
(572, 'Karwinskia humboldtiana', 'Lu\'um che\'', 'Rhamnaceae', 'Árbol o arbusto', 'Karwinskia', ''),
(573, 'Krugiodendron ferreum', 'Quiebra hacha', 'Rhamnaceae', 'Árbol o arbusto', 'Krugiodendron', ''),
(574, 'Laetia thamnia', 'Zapote amarillo', 'Salicaceae', 'Árbol', 'Laetia', ''),
(575, 'Lantana camara', 'Oregano de monte', 'Verbenaceae', 'Arbusto', 'Lantana', ''),
(576, 'Lantana involucrata', 'Orégano xiu', 'Verbenaceae', 'Arbusto', 'Lantana', ''),
(577, 'Lasiacis divaricata', 'Táabil siit', 'Poaceae', 'Herbácea', 'Lasiacis', ''),
(578, 'Leucaena leucocephala', 'Waxim', 'Leguminosae', 'Árbol', 'Leucaena', ''),
(579, 'Licaria campechiana', 'Jo\' che\'', 'Lauraceae', 'Árbol', 'Licaria', ''),
(580, 'Licaria peckii', 'Chobenche', 'Lauraceae', 'Árbol', 'Licaria', ''),
(581, 'Lonchocarpus guatemalensis', 'Xul', 'Leguminosae', 'Árbol', 'Lonchocarpus', ''),
(582, 'Lonchocarpus hondurensis', 'Ya\'ax ha\'bin', 'Leguminosae', 'Árbol', 'Lonchocarpus', ''),
(583, 'Lonchocarpus luteomaculatus', 'Xbalche', 'Leguminosae', 'Árbol o arbusto', 'Lonchocarpus', ''),
(584, 'Lonchocarpus punctatus', 'Baal che\'', 'Leguminosae', 'Árbol', 'Lonchocarpus', ''),
(585, 'Lonchocarpus rugosus', 'Kanasin', 'Leguminosae', 'Árbol', 'Lonchocarpus', ''),
(586, 'Luehea speciosa', 'Guasimo blanco', 'Malvaceae', 'Árbol', 'Luehea', ''),
(587, 'Lysiloma latisiliquum', 'Tzalam', 'Leguminosae', 'Árbol', 'Lysiloma', ''),
(588, 'Machaonia lindeniana', 'K\'anpokolche\'', 'Rubiaceae', 'Árbol o arbusto', 'Machaonia', ''),
(589, 'Maclura tinctoria', 'Mora', 'Moraceae', 'Árbol', 'Maclura', ''),
(590, 'Malpighia glabra', 'Chi nance', 'Malpighiaceae', 'Árbol o arbusto', 'Malpighia', ''),
(591, 'Malpighia lundellii', 'Wayakté', 'Malpighiaceae', 'Arbusto', 'Malpighia', ''),
(592, 'Malvaviscus arboreus', 'Tulipancillo', 'Malvaceae', 'Arbusto', 'Malvaviscus', ''),
(593, 'Mammillaria columbiana', 'Biznaga yucateca', 'Cactaceae', 'Cactus', 'Mammillaria', ''),
(594, 'Manilkara zapota', 'Chicozapote', 'Sapotaceae', 'Árbol', 'Manilkara', ''),
(595, 'Mariosousa dolichostachya', 'Mariosousa', 'Leguminosae', 'Árbol', 'Mariosousa', ''),
(596, 'Matelea crassifolia', 'Tokil, x-tokil', 'Asclepiadaceae', 'Bejuco', 'Matelea', ''),
(597, 'Melampodium divaricatum', 'Tajonal', 'Asteraceae', 'Herbácea', 'Melampodium', ''),
(598, 'Melanthera aspera', 'Yerba de cabra', 'Asteraceae', 'Herbácea', 'Melanthera', ''),
(599, 'Melicoccus oliviformis', 'Huaya', 'Sapindaceae', 'Árbol', 'Melicoccus', ''),
(600, 'Metopium brownei', 'Chechem', 'Anacardiaceae', 'Árbol', 'Metopium', ''),
(601, 'Mimosa bahamensis', 'Káatsim', 'Leguminosae', 'Árbol', 'Mimosa', ''),
(602, 'Morella cerifera', 'Kibche’', 'Myricaceae', 'Árbol o arbusto', 'Morella', ''),
(603, 'Morinda royoc', 'Hoyok', 'Rubiaceae', 'Arbusto', 'Morinda', ''),
(604, 'Mosannona depressa', 'Ek elemuy', 'Annonaceae', 'Árbol', 'Mosannona', ''),
(605, 'Muntingia calabura', 'Capulin', 'Muntigiaceae', 'Árbol', 'Muntingia', ''),
(606, 'Myrcianthes fragrans', 'Guayabillo', 'Myrtaceae', 'Árbol o arbusto', 'Myrcianthes', ''),
(607, 'Myrmecophila brysiana', 'Orquidea', 'Orchidaceae', 'Herbácea', 'Myrmecophila', ''),
(608, 'Nectandra coriacea', 'Aguacatillo', 'Lauraceae', 'Árbol', 'Nectandra', ''),
(609, 'Nectandra hihua', 'Jigua', 'Lauraceae', 'Árbol', 'Nectandra', ''),
(610, 'Nectandra salicifolia', 'Laurelillo', 'Lauraceae', 'Árbol', 'Nectandra', ''),
(611, 'Nectandra sanguinea', 'Hooch\'oche', 'Lauraceae', 'Árbol', 'Nectandra', ''),
(612, 'Neea psychotrioides', 'Tadzi', 'Nyctaginaceae', 'Árbol o arbusto', 'Neea', ''),
(613, 'Neomillspaughia emarginata', 'Sak iitsa', 'Polygonaceae', 'Árbol o arbusto', 'Neomillspaughia', ''),
(614, 'Nopalea gaumeri', 'Tsakam', 'Cactaceae', 'Arbusto', 'Nopalea', ''),
(615, 'Ocotea veraguensis', 'Ocotea', 'Lauraceae', 'Árbol', 'Ocotea', ''),
(616, 'Oeceoclades maculata', 'Orquidea de piso', 'Orchidaceae', 'Herbácea', 'Oeceoclades', ''),
(617, 'Oplismenus hirtellus', 'Cadillo', 'Poaceae', 'Herbácea', 'Oplismenus', ''),
(618, 'Opuntia stricta var. Dillenii', 'Pak\' am', 'Cactaceae', 'Cactus', 'Opuntia', ''),
(619, 'Ornithocephalus inflexus', 'Orquídea', 'Orchidaceae', 'Herbácea', 'Ornithocephalus', ''),
(620, 'Otopappus curviflorus', 'Sohbakche\'', 'Asteraceae', 'Arbusto', 'Otopappus', ''),
(621, 'Ottoschulzia pallida', 'Uvas che\'', 'Icacinaceae', 'Árbol', 'Ottoschulzia', ''),
(622, 'Oxandra lanceolata', 'Ya\'ya', 'Annonaceae', 'Árbol', 'Oxandra', ''),
(623, 'Parathesis cubana', 'Pico de paloma', 'Primulaceae', 'Árbol o arbusto', 'Parathesis', ''),
(624, 'Paspalum paniculatum', 'Césped del mar', 'Poaceae', 'Herbácea', 'Paspalum', ''),
(625, 'Passiflora foetida', 'Pasionaria', 'Passifloraceae', 'Trepadora', 'Passiflora', ''),
(626, 'Paullinia clavigera', 'Sakam', 'Sapindaceae', 'Bejuco', 'Paullinia', ''),
(627, 'Paullinia cururu', 'Bejuco alado', 'Sapindaceae', 'Bejuco', 'Paullinia', ''),
(628, 'Paullinia pinnata', 'Salatxiw', 'Sapindaceae', 'Bejuco', 'Paullinia', ''),
(629, 'Pentalinon andrieuxii', 'Bejuco guaco', 'Apocynaceae', 'Bejuco', 'Pentalinon', ''),
(630, 'Petrea volubilis', 'Optsimin', 'Verbenaceae', 'Bejuco', 'Petrea', ''),
(631, 'Philodendron jacquinii', 'Baston de viejo', 'Araceae', 'Epífita', 'Philodendron', ''),
(632, 'Phragmites australis', 'Carrizo', 'Poaceae', 'Herbácea', 'Phragmites', ''),
(633, 'Phyla nodiflora', 'Ich ch’o', 'Verbenaceae', 'Herbácea', 'Phyla', ''),
(634, 'Phyllanthus graveolens', 'Xiiw k\'iin', 'Phyllanthaceae', 'Árbol o arbusto', 'Phyllanthus', ''),
(635, 'Picramnia antidesma', 'K\'aan chik\'in che\'', 'Picramniaceae', 'Árbol o arbusto', 'Picramnia', ''),
(636, 'Pilocarpus racemosus', 'Naranjillo', 'Rutaceae', 'Árbol', 'Pilocarpus', ''),
(637, 'Piper amalago', 'Cordoncillo', 'Piperaceae', 'Arbusto', 'Piper', ''),
(638, 'Piscidia piscipula', 'Jabín', 'Leguminosae', 'Árbol', 'Piscidia', ''),
(639, 'Pisonia aculeata', 'Beeb', 'Nyctaginaceae', 'Bejuco', 'Pisonia', ''),
(640, 'Pithecellobium dulce', 'Dsiuché', 'Leguminosae', 'Árbol', 'Pithecellobium', ''),
(641, 'Pithecellobium keyense', 'Ya\'ax k\'aax', 'Leguminosae', 'Arbusto', 'Pithecellobium', ''),
(642, 'Platymiscium yucatanum', 'Granadillo', 'Leguminosae', 'Árbol', 'Platymiscium', ''),
(643, 'Plumeria obtusa var. Sericifolia', 'Flor de mayo', 'Apocynaceae', 'Árbol o arbusto', 'Plumeria', ''),
(644, 'Plumeria rubra', 'Sach-nicte flor de mayo', 'Apocynaceae', 'Árbol', 'Plumeria', ''),
(645, 'Pouteria campechiana', 'Kaniste', 'Sapotaceae', 'Árbol', 'Pouteria', ''),
(646, 'Pouteria glomerata', 'Chooch', 'Sapotaceae', 'Árbol', 'Pouteria', ''),
(647, 'Pouteria reticulata', 'Zapotillo', 'Sapotaceae', 'Árbol', 'Pouteria', ''),
(648, 'Protium confusum', 'Pom', 'Burseraceae', 'Árbol', 'Protium', ''),
(649, 'Protium copal', 'Copal', 'Burseraceae', 'Árbol', 'Protium', ''),
(650, 'Psidium sartorianum', 'X-pichi\'che', 'Myrtaceae', 'Árbol', 'Psidium', ''),
(651, 'Psychotria nervosa', 'Café de Monte', 'Rubiaceae', 'Arbusto', 'Psychotria', ''),
(652, 'Psychotria pubescens', 'Lunche\'', 'Rubiaceae', 'Arbusto', 'Psychotria', ''),
(653, 'Pteridium aquilinum', 'Helecho Cilantrillo', 'Dennstaedtiaceae', 'Herbácea', 'Pteridium', ''),
(654, 'Pteridium caudatum', 'Cilantrillo', 'Dennstaedtiaceae', 'Herbácea', 'Pteridium', ''),
(655, 'Pterocarpus rohrii', 'Aldrago', 'Leguminosae', 'Árbol', 'Pterocarpus', ''),
(656, 'Randia aculeata', 'Cruceta', 'Rubiaceae', 'Arbusto', 'Randia', ''),
(657, 'Randia armata', 'Peech kitam', 'Rubiaceae', 'Arbusto', 'Randia', ''),
(658, 'Randia longiloba', 'K\'aax', 'Rubiaceae', 'Arbusto', 'Randia', ''),
(659, 'Randia monantha', 'Crucetillo', 'Rubiaceae', 'Arbusto', 'Randia', ''),
(660, 'Randia obcordata', 'Cruz k\'iix', 'Rubiaceae', 'Arbusto', 'Randia', ''),
(661, 'Randia truncata', 'Pechkitam', 'Rubiaceae', 'Arbusto', 'Randia', ''),
(662, 'Rhabdadenia biflora', 'Bejuco de manglar', 'Apocynaceae', 'Bejuco', 'Rhabdadenia', ''),
(663, 'Rudgea alvarezii', 'Árbol ruda', 'Rubiaceae', 'Arbusto', 'Rudgea', ''),
(664, 'Sabal yapa', 'Palma xa\'an', 'Arecaceae', 'Palma', 'Sabal', ''),
(665, 'Salvia micrantha', 'K\' aaj xiiw', 'Lamiaceae', 'Herbácea', 'Salvia', ''),
(666, 'Samyda yucatanensis', 'Puuts\' mukuy', 'Salicaceae', 'Arbusto', 'Samyda', ''),
(667, 'Sapindus saponaria', 'Jaboncillo sibom', 'Sapindaceae', 'Árbol', 'Sapindus', ''),
(668, 'Sapium glandulosum', 'Pozol agrio', 'Euphorbiaceae', 'Árbol', 'Sapium', ''),
(669, 'Sapium macrocarpum', 'Palo lechón', 'Euphorbiaceae', 'Árbol', 'Sapium', ''),
(670, 'Sapranthus campechianus', 'Zac elemuy', 'Annonaceae', 'Arbusto', 'Sapranthus', ''),
(671, 'Scaevola plumieri', 'Arbusto de playa', 'Goodeniaceae', 'Herbácea', 'Scaevola', ''),
(672, 'Sebastiania adenophora', 'sak chée chem', 'Euphorbiaceae', 'Herbácea', 'Sebastiania', ''),
(673, 'Semialarium mexicanum', 'Cascarillo grueso', 'Celastraceae', 'Árbol', 'Semialarium', ''),
(674, 'Senna pallida', 'Mo\'ol che\'', 'Leguminosae', 'Arbusto', 'Senna', ''),
(675, 'Serjania adiantoides', 'Buy', 'Sapindaceae', 'Bejuco', 'Serjania', ''),
(676, 'Serjania goniocarpa', 'Bejuco tres lomos', 'Sapindaceae', 'Bejuco', 'Serjania', ''),
(677, 'Serjania yucatanensis', 'Buy-ak\' tres hojas', 'Sapindaceae', 'Bejuco', 'Serjania', ''),
(678, 'Sideroxylon celastrinum', 'Lu\'uchum che\'', 'Sapotaceae', 'Arbusto', 'Sideroxylon', ''),
(679, 'Sideroxylon foetidissimum', 'K’anaste’', 'Sapotaceae', 'Árbol', 'Sideroxylon', ''),
(680, 'Sideroxylon obtusifolium', 'Sideroxylon', 'Sapotaceae', 'Árbol', 'Sideroxylon', ''),
(681, 'Sideroxylon persimile', 'Bóol chi che\'', 'Sapotaceae', 'Árbol', 'Sideroxylon', ''),
(682, 'Sideroxylon salicifolium', 'Zapote faisán', 'Sapotaceae', 'Arbusto', 'Sideroxylon', ''),
(683, 'Simarouba amara', 'Pasak', 'Simaroubaceae', 'Árbol', 'Simarouba', ''),
(684, 'Smilax mollis', 'Bejuco diente de perro', 'Smilacaceae', 'Trepadora', 'Smilax', ''),
(685, 'Solanum erianthum', 'Tóom p\'aak', 'Solanaceae', 'Arbusto', 'Solanum', ''),
(686, 'Sphinga platyloba', 'Sierrilla con espinas', 'Leguminosae', 'Arbusto', 'Sphinga', ''),
(687, 'Spondias mombin', 'Jobo', 'Anacardiaceae', 'Árbol', 'Spondias', ''),
(688, 'Spondias purpurea', 'El ciruelo colorado', 'Anacardiaceae', 'Árbol', 'Spondias', ''),
(689, 'Spondias radlkoferi', 'Ciruela', 'Anacardiaceae', 'Árbol', 'Spondias', ''),
(690, 'Stenostomum lucidum', 'Palo de rosa', 'Rubiaceae', 'Árbol', 'Stenostomum', ''),
(691, 'Stizophyllum riparium', 'Bejuco frijolillo', 'Bignoniaceae', 'Bejuco', 'Stizophyllum', ''),
(692, 'Strophocactus testudo', 'Pitaya tortuga', 'Cactaceae', 'Cactus', 'Strophocactus', ''),
(693, 'Strychnos panamensis', 'Strychnos', 'Loganiaceae', 'Bejuco', 'Strychnos', ''),
(694, 'Suriana maritima', 'Xpants’ xiw', 'Surianaceae', 'Arbusto', 'Suriana', ''),
(695, 'Swartzia cubensis', 'Katalox', 'Leguminosae', 'Árbol', 'Swartzia', ''),
(696, 'Swietenia macrophylla', 'Caoba', 'Meliaceae', 'Árbol', 'Swietenia', ''),
(697, 'Tabebuia chrysantha', 'K\'an lool', 'Bignoniaceae', 'Árbol', 'Tabebuia', ''),
(698, 'Tabebuia rosea', 'Maculis', 'Bignoniaceae', 'Árbol', 'Tabebuia', ''),
(699, 'Terminalia catappa', 'Almendro', 'Combretaceae', 'Árbol', 'Terminalia', ''),
(700, 'Ternstroemia tepezapote', 'Tepezapote', 'Theaceae', 'Árbol', 'Ternstroemia', ''),
(701, 'Tetracera volubilis', 'Bejuco de canasta', 'Dilleniaceae', 'Arbusto', 'Tetracera', ''),
(702, 'Thouinia paucidentata', 'K\'an chuunup', 'Sapindaceae', 'Arbusto', 'Thouinia', ''),
(703, 'Thrinax radiata', 'Palma chit', 'Arecaceae', 'Palma', 'Thrinax', ''),
(704, 'Tillandsia brachycaulos', 'Gallitos', 'Bromeliaceae', 'Acaulescente', 'Tillandsia', ''),
(705, 'Toxicodendron radicans', 'Chechem-ak\'', 'Anacardiaceae', 'Arbusto', 'Toxicodendron', ''),
(706, 'Trichilia erythrocarpa', 'Trichilia', 'Meliaceae', 'Árbol', 'Trichilia', ''),
(707, 'Trichilia glabra', 'Choobem che\'', 'Meliaceae', 'Árbol', 'Trichilia', ''),
(708, 'Trichilia hirta', 'K\'ulim siis', 'Meliaceae', 'Árbol', 'Trichilia', ''),
(709, 'Trichilia minutiflora', 'Tsiimin che\'', 'Meliaceae', 'Árbol', 'Trichilia', ''),
(710, 'Trichilia pallida', 'Caracolillo', 'Meliaceae', 'Árbol', 'Trichilia', ''),
(711, 'Trophis racemosa', 'Chac ox', 'Moraceae', 'Árbol', 'Trophis', ''),
(712, 'Tynanthus guatemalensis', 'Café ac', 'Bignoniaceae', 'Bejuco', 'Tynanthus', ''),
(713, 'Typha domingensis', 'Tule', 'Typhaceae', 'Acuatica', 'Typha', ''),
(714, 'Urvillea ulmacea', 'Bejuco zizus Ap\'aak', 'Sapindaceae', 'Bejuco', 'Urvillea', ''),
(715, 'Vigna candida', 'Bejuquillo tres hojas', 'Leguminosae', 'Bejuco', 'Vigna', ''),
(716, 'Vitex gaumeri', 'Ya\'axnik', 'Lamiaceae', 'Árbol', 'Vitex', ''),
(717, 'Wimmeria lundelliana', 'no tiene', 'Celastraceae', 'Árbol', 'Wimmeria', ''),
(718, 'Wimmeria obtusifolia', 'no tiene', 'Celastraceae', 'Árbol', 'Wimmeria', ''),
(719, 'Zanthoxylum caribaeum', 'K\'ek \'en che\'', 'Rutaceae', 'Árbol', 'Zanthoxylum', ''),
(720, 'Zanthoxylum fagara', 'Si na\'an che\'', 'Rutaceae', 'Árbol o arbusto', 'Zanthoxylum', ''),
(721, 'Ziziphus mauritiana', 'Ciruela de monte', 'Rhamnaceae', 'Árbol o arbusto', 'Ziziphus', ''),
(722, 'Ziziphus yucatanensis', 'Ciruelillo', 'Rhamnaceae', 'Árbol', 'Ziziphus', ''),
(723, 'Zuelania guidonia', 'Tamay', 'Salicaceae', 'Árbol', 'Zuelania', ''),
(724, 'Zygia cognata', 'Cacao che', 'Leguminosae', 'Árbol o arbusto', 'Zygia', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `familias`
--

CREATE TABLE `familias` (
  `id` int(11) NOT NULL,
  `familia` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `familias`
--

INSERT INTO `familias` (`id`, `familia`) VALUES
(1, 'banana'),
(4, 'perro'),
(2, 'pijama'),
(3, 'popo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `generos`
--

CREATE TABLE `generos` (
  `id` int(11) NOT NULL,
  `familia_id` int(11) NOT NULL,
  `genero` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `generos`
--

INSERT INTO `generos` (`id`, `familia_id`, `genero`) VALUES
(1, 1, 'cha'),
(2, 1, 'che'),
(3, 2, 'chi'),
(4, 2, 'cho'),
(5, 3, 'chango'),
(7, 3, 'chango'),
(8, 4, 'blah'),
(9, 4, 'perrorro'),
(10, 2, 'pat');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `individuos`
--

CREATE TABLE `individuos` (
  `id` int(11) NOT NULL,
  `proyecto_id` int(11) NOT NULL,
  `sitio` int(11) NOT NULL,
  `area` int(11) NOT NULL,
  `cuadrante` int(11) DEFAULT NULL,
  `numero` int(11) NOT NULL,
  `arbolnumeroensitio` int(11) NOT NULL,
  `bifurcados` tinyint(1) DEFAULT NULL,
  `nombrecientifico` varchar(40) DEFAULT NULL,
  `nombrecomun` varchar(40) DEFAULT NULL,
  `familia` varchar(40) DEFAULT NULL,
  `genero` varchar(40) DEFAULT NULL,
  `perimetro` decimal(10,4) DEFAULT NULL,
  `diametro` decimal(10,4) DEFAULT NULL,
  `alturafl` decimal(10,4) DEFAULT NULL,
  `alturatotal` decimal(10,4) DEFAULT NULL,
  `coberturalargo` decimal(10,4) DEFAULT NULL,
  `coberturaancho` decimal(10,4) DEFAULT NULL,
  `formadefuste` varchar(20) DEFAULT NULL,
  `estadocondicion` varchar(20) DEFAULT NULL,
  `rad` decimal(10,4) DEFAULT NULL,
  `atcategorias` decimal(10,4) DEFAULT NULL,
  `dncategorias` int(11) DEFAULT NULL,
  `ab` decimal(10,4) DEFAULT NULL,
  `grupo` int(11) DEFAULT NULL,
  `volumenvv` decimal(10,8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

--
-- Volcado de datos para la tabla `individuos`
--

INSERT INTO `individuos` (`id`, `proyecto_id`, `sitio`, `area`, `cuadrante`, `numero`, `arbolnumeroensitio`, `bifurcados`, `nombrecientifico`, `nombrecomun`, `familia`, `genero`, `perimetro`, `diametro`, `alturafl`, `alturatotal`, `coberturalargo`, `coberturaancho`, `formadefuste`, `estadocondicion`, `rad`, `atcategorias`, `dncategorias`, `ab`, `grupo`, `volumenvv`) VALUES
(107, 11, 1, 500, NULL, 1, 1, 0, 'Lysiloma latisiliquum', 'Tzalam', 'Leguminosae', 'Lysiloma', '75.9951', '24.1900', NULL, '10.0000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 3, '0.23465706'),
(108, 11, 1, 500, NULL, 2, 2, 0, 'Swartzia cubensis', 'Katalox', 'Leguminosae', 'Swartzia', '12.5664', '4.0000', NULL, '3.1000', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 4, '0.00265781');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proyectos`
--

CREATE TABLE `proyectos` (
  `id` int(11) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `superficie` decimal(11,4) NOT NULL,
  `sector` varchar(20) NOT NULL,
  `descripcion` varchar(400) DEFAULT NULL,
  `kml` mediumblob,
  `kml_url` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;

--
-- Volcado de datos para la tabla `proyectos`
--

INSERT INTO `proyectos` (`id`, `nombre`, `superficie`, `sector`, `descripcion`, `kml`, `kml_url`) VALUES
(11, 'Ejemplo', '120.0000', 'ejemplo', 'ejemploejemploejemploejemploejemplo', NULL, 'C:\\Users\\poseidon9\\Downloads\\ejemplo.kml');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sitios`
--

CREATE TABLE `sitios` (
  `id` int(11) NOT NULL,
  `proyecto_id` int(11) NOT NULL,
  `numero_sitio` int(11) NOT NULL,
  `coordenada_x` decimal(11,4) DEFAULT NULL,
  `coordenada_y` decimal(11,4) DEFAULT NULL,
  `municipio` varchar(20) DEFAULT NULL,
  `estado_sucesional` varchar(20) DEFAULT NULL,
  `numero_consecutivo1` int(11) NOT NULL DEFAULT '1',
  `numero_consecutivo2` int(11) NOT NULL DEFAULT '1',
  `numero_consecutivo3` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `sitios`
--

INSERT INTO `sitios` (`id`, `proyecto_id`, `numero_sitio`, `coordenada_x`, `coordenada_y`, `municipio`, `estado_sucesional`, `numero_consecutivo1`, `numero_consecutivo2`, `numero_consecutivo3`) VALUES
(14, 11, 1, NULL, NULL, NULL, NULL, 3, 1, 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `especies`
--
ALTER TABLE `especies`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `familias`
--
ALTER TABLE `familias`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `familia` (`familia`);

--
-- Indices de la tabla `generos`
--
ALTER TABLE `generos`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `individuos`
--
ALTER TABLE `individuos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `proyecto_id_fk` (`proyecto_id`);

--
-- Indices de la tabla `proyectos`
--
ALTER TABLE `proyectos`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nombre` (`nombre`);

--
-- Indices de la tabla `sitios`
--
ALTER TABLE `sitios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `proyecto_id_fk2` (`proyecto_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `especies`
--
ALTER TABLE `especies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=725;
--
-- AUTO_INCREMENT de la tabla `familias`
--
ALTER TABLE `familias`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `generos`
--
ALTER TABLE `generos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT de la tabla `individuos`
--
ALTER TABLE `individuos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=109;
--
-- AUTO_INCREMENT de la tabla `proyectos`
--
ALTER TABLE `proyectos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT de la tabla `sitios`
--
ALTER TABLE `sitios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `individuos`
--
ALTER TABLE `individuos`
  ADD CONSTRAINT `proyecto_id_fk` FOREIGN KEY (`proyecto_id`) REFERENCES `proyectos` (`id`);

--
-- Filtros para la tabla `sitios`
--
ALTER TABLE `sitios`
  ADD CONSTRAINT `proyecto_id_fk2` FOREIGN KEY (`proyecto_id`) REFERENCES `proyectos` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
