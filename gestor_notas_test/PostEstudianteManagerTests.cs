using gestor_notas.DTO;
using gestor_notas.Manager;
using gestor_notas.DAO.Interface;
using gestor_notas.Common.Interface;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas_test
{
 [TestFixture]
 public class PostEstudianteManagerTests
 {
 private Mock<IPostgresConnection> _postgresConnectionMock;
 private Mock<IPostEstudianteDAO> _postEstudianteDAOMock;
 private PostEstudianteManager _postEstudianteManager;
 private NpgsqlConnection _realConnection;

 [SetUp]
 public void Setup()
 {
 _postgresConnectionMock = new Mock<IPostgresConnection>();
 _postEstudianteDAOMock = new Mock<IPostEstudianteDAO>();
 _postEstudianteManager = new PostEstudianteManager(_postgresConnectionMock.Object, _postEstudianteDAOMock.Object);
 _realConnection = new NpgsqlConnection(); // Replace with a valid connection string for testing
 }

 [TearDown]
 public void TearDown()
 {
 _realConnection.Dispose();
 }

 [Test]
 public async Task AddEstudianteAsync_ShouldReturnTrue_WhenSuccessful()
 {
 // Arrange
 var estudianteDTO = new EstudianteDTO { Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _postEstudianteDAOMock.Setup(p => p.AddEstudianteAsync(It.IsAny<NpgsqlConnection>(), estudianteDTO)).ReturnsAsync(true);

 // Act
 var result = await _postEstudianteManager.AddEstudianteAsync(estudianteDTO);

 // Assert
 Assert.That(result, Is.True);
 }

 [Test]
 public async Task AddEstudianteAsync_ShouldReturnFalse_WhenFails()
 {
 // Arrange
 var estudianteDTO = new EstudianteDTO { Nombre = "Juan Pérez" };
 _postgresConnectionMock.Setup(p => p.GetConnection()).Returns(_realConnection);
 _postEstudianteDAOMock.Setup(p => p.AddEstudianteAsync(It.IsAny<NpgsqlConnection>(), estudianteDTO)).ReturnsAsync(false);

 // Act
 var result = await _postEstudianteManager.AddEstudianteAsync(estudianteDTO);

 // Assert
 Assert.That(result, Is.False);
 }
 }
}